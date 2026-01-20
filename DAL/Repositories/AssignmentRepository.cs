using DAL.Interfaces;
using DTOs.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AssignmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Assignment>> GetAssignmentsByAnnotatorAsync(int projectId, string annotatorId)
        {
            var query = _context.Assignments
                .Include(a => a.DataItem) 
                .Include(a => a.Project)
                .Where(a => a.AnnotatorId == annotatorId);

            if (projectId > 0)
            {
                query = query.Where(a => a.ProjectId == projectId);
            }

            return await query.OrderByDescending(a => a.AssignedDate).ToListAsync();
        }

        public async Task<List<Assignment>> GetAssignmentsForReviewerAsync(int projectId)
        {
            return await _context.Assignments
                .Include(a => a.DataItem)   
                .Include(a => a.Annotator)  
                .Where(a => a.ProjectId == projectId && a.Status == "Submitted")
                .OrderBy(a => a.SubmittedAt)
                .ToListAsync();
        }

        public async Task<Assignment?> GetAssignmentWithDetailsAsync(int assignmentId)
        {
            return await _context.Assignments
                .Include(a => a.DataItem)
                .Include(a => a.Project)
                    .ThenInclude(p => p.LabelClasses)
                .Include(a => a.Annotations)
                .Include(a => a.ReviewLogs)
                .FirstOrDefaultAsync(a => a.Id == assignmentId);
        }
        public async Task<List<DataItem>> GetUnassignedDataItemsAsync(int projectId, int quantity)
        {
            return await _context.DataItems
                .Where(d => d.ProjectId == projectId && d.Status == "New")
                .Take(quantity)
                .ToListAsync();
        }
    }
}