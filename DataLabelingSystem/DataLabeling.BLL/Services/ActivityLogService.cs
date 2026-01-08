using DataLabeling.Core.DTOs;
using DataLabeling.Core.Entities;
using DataLabeling.Core.Interfaces;
using DataLabeling.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLabeling.BLL.Services
{
    public class ActivityLogService : IActivityLogService
    {
        private readonly AppDbContext _context;

        public ActivityLogService(AppDbContext context)
        {
            _context = context;
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

            await _context.Set<ActivityLog>().AddAsync(log);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ActivityLogDto>> GetLogsAsync()
        {
            // Join with Users to get username if UserId is present
            var query = from log in _context.Set<ActivityLog>()
                        join u in _context.Users on log.UserId equals u.Id into users
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