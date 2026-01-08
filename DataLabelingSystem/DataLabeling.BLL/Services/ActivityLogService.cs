using DataLabeling.Core.DTOs;
using DataLabeling.Core.Entities;
using DataLabeling.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLabeling.BLL.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ActivityLogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task LogAsync(int? userId, string action, string entityType, string entityId, string details = "")
        {
            var log = new ActivityLog
            {
                UserId = userId,
                Action = action,
                EntityType = entityType,
                EntityId = entityId,
                Details = details,
                Timestamp = DateTime.Now
            };

            await _unitOfWork.Repository<ActivityLog>().AddAsync(log);
            await _unitOfWork.CompleteAsync();
        }

        public async Task<IEnumerable<ActivityLogDto>> GetLogsAsync()
        {
            var logsQuery = _unitOfWork.Repository<ActivityLog>().AsQueryable();
            var usersQuery = _unitOfWork.Repository<User>().AsQueryable();
            var query = from log in logsQuery
                        join u in usersQuery on log.UserId equals u.Id into users
                        from user in users.DefaultIfEmpty()
                        orderby log.Timestamp descending
                        select new ActivityLogDto
                        {
                            Id = log.Id,
                            UserName = user != null ? user.Username : "System/Unknown",
                            Action = log.Action,
                            EntityType = log.EntityType,
                            EntityId = log.EntityId,
                            Details = log.Details,
                            Timestamp = log.Timestamp
                        };

            return await query.ToListAsync();
        }
    }
}