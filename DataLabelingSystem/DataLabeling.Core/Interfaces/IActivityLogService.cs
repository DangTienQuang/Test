using DataLabeling.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLabeling.Core.Interfaces
{
    public interface IActivityLogService
    {
        Task LogAsync(int? userId, string action, string entityType, string entityId, string details = "");
        Task<IEnumerable<ActivityLogDto>> GetLogsAsync();
    }
}