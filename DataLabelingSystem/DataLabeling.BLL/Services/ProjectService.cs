using DataLabeling.Core.DTOs;
using DataLabeling.Core.Entities;
using DataLabeling.Core.Enums;
using DataLabeling.Core.Interfaces;
using DataLabeling.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLabeling.BLL.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly AppDbContext _context;

        public ProjectService(IUnitOfWork unitOfWork, AppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<ProjectViewDto> CreateProjectAsync(CreateProjectDto dto)
        {
            var manager = await _unitOfWork.Repository<User>().GetByIdAsync(dto.ManagerId);
            if (manager == null) throw new Exception("Người quản lý (ManagerId) không tồn tại.");

            var project = new Project
            {
                Name = dto.Name,
                Description = dto.Description,
                Instruction = dto.Instruction,
                LabelConfig = dto.LabelConfig,
                ManagerId = dto.ManagerId,
                CreatedDate = DateTime.Now
            };

            await _unitOfWork.Repository<Project>().AddAsync(project);
            await _unitOfWork.CompleteAsync();

            return new ProjectViewDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                ManagerName = manager.FullName,
                TotalImages = 0
            };
        }
        public async Task<int> AddDataItemsAsync(AddDataItemDto dto)
        {
            var project = await _unitOfWork.Repository<Project>().GetByIdAsync(dto.ProjectId);
            if (project == null) throw new Exception("Dự án không tồn tại.");

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var dataItems = new List<DataItem>();
                var tasks = new List<LabelTask>();

                foreach (var url in dto.ImageUrls)
                {
                    var item = new DataItem
                    {
                        DataUrl = url,
                        FileName = System.IO.Path.GetFileName(url),
                        ProjectId = dto.ProjectId
                    };
                    dataItems.Add(item);
                }

                await _context.DataItems.AddRangeAsync(dataItems);
                await _context.SaveChangesAsync();

                foreach (var item in dataItems)
                {
                    tasks.Add(new LabelTask
                    {
                        DataItemId = item.Id,
                        Status = ProjectTaskStatus.New,
                        AnnotatorId = null,
                        LabelData = null
                    });
                }

                await _context.LabelTasks.AddRangeAsync(tasks);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return dataItems.Count;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<IEnumerable<ProjectViewDto>> GetProjectsByManagerAsync(int managerId)
        {
            return await _context.Projects
                .Where(p => p.ManagerId == managerId)
                .Select(p => new ProjectViewDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ManagerName = p.Manager.FullName,
                    TotalImages = p.DataItems.Count()
                })
                .ToListAsync();
        }

        public async Task<ProjectProgressDto> GetProjectProgressAsync(int projectId)
        {
            var projectExists = await _context.Projects.AnyAsync(p => p.Id == projectId);
            if (!projectExists) throw new Exception("Dự án không tồn tại.");

            var dataItems = await _context.DataItems
                                          .Include(d => d.LabelTask)
                                          .Where(d => d.ProjectId == projectId)
                                          .ToListAsync();

            var stats = new ProjectProgressDto
            {
                ProjectId = projectId,
                TotalItems = dataItems.Count,
                NewItems = dataItems.Count(d => d.LabelTask == null || d.LabelTask.Status == ProjectTaskStatus.New),
                InProgressItems = dataItems.Count(d => d.LabelTask != null && d.LabelTask.Status == ProjectTaskStatus.InProgress),
                SubmittedItems = dataItems.Count(d => d.LabelTask != null && d.LabelTask.Status == ProjectTaskStatus.Submitted),
                RejectedItems = dataItems.Count(d => d.LabelTask != null && d.LabelTask.Status == ProjectTaskStatus.Rejected),
                ApprovedItems = dataItems.Count(d => d.LabelTask != null && d.LabelTask.Status == ProjectTaskStatus.Approved)
            };

            if (stats.TotalItems > 0)
            {
                stats.PercentComplete = Math.Round((double)stats.ApprovedItems / stats.TotalItems * 100, 2);
            }

            return stats;
        }

        public async Task<IEnumerable<ExportDataItemDto>> ExportApprovedDataAsync(int projectId)
        {
            var query = from d in _context.DataItems
                        join t in _context.LabelTasks on d.Id equals t.DataItemId
                        join u in _context.Users on t.AnnotatorId equals u.Id into users
                        from annotator in users.DefaultIfEmpty()
                        where d.ProjectId == projectId && t.Status == ProjectTaskStatus.Approved
                        select new ExportDataItemDto
                        {
                            Id = d.Id,
                            FileName = d.FileName,
                            Url = d.DataUrl,
                            LabelData = t.LabelData,
                            AnnotatorName = annotator != null ? annotator.FullName : "Unknown",
                            ReviewerComment = t.ReviewerComment
                        };

            return await query.ToListAsync();
        }
    }
}