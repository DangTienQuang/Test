using DataLabeling.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLabeling.Core.Interfaces
{
    public interface ISystemConfigService
    {
        Task<IEnumerable<SystemConfigDto>> GetAllConfigsAsync();
        Task<SystemConfigDto> GetConfigByKeyAsync(string key);
        Task<SystemConfigDto> UpdateConfigAsync(UpdateSystemConfigDto dto);
    }
}