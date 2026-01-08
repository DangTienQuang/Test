using DataLabeling.Core.DTOs;
using DataLabeling.Core.Entities;
using DataLabeling.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLabeling.BLL.Services
{
    public class SystemConfigService : ISystemConfigService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SystemConfigService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<SystemConfigDto>> GetAllConfigsAsync()
        {
            return await _unitOfWork.Repository<SystemConfig>()
                .AsQueryable()
                .Select(c => new SystemConfigDto
                {
                    Id = c.Id,
                    Key = c.Key,
                    Value = c.Value,
                    Description = c.Description
                })
                .ToListAsync();
        }

        public async Task<SystemConfigDto> GetConfigByKeyAsync(string key)
        {
            var configs = await _unitOfWork.Repository<SystemConfig>().FindAsync(c => c.Key == key);
            var config = configs.FirstOrDefault();

            if (config == null) return null;

            return new SystemConfigDto
            {
                Id = config.Id,
                Key = config.Key,
                Value = config.Value,
                Description = config.Description
            };
        }

        public async Task<SystemConfigDto> UpdateConfigAsync(UpdateSystemConfigDto dto)
        {
            var configs = await _unitOfWork.Repository<SystemConfig>().FindAsync(c => c.Key == dto.Key);
            var config = configs.FirstOrDefault();

            if (config == null)
            {
                config = new SystemConfig
                {
                    Key = dto.Key,
                    Value = dto.Value,
                    Description = "Auto-created"
                };
                await _unitOfWork.Repository<SystemConfig>().AddAsync(config);
            }
            else
            {
                config.Value = dto.Value;
                _unitOfWork.Repository<SystemConfig>().Update(config);
            }

            await _unitOfWork.CompleteAsync();

            return new SystemConfigDto
            {
                Id = config.Id,
                Key = config.Key,
                Value = config.Value,
                Description = config.Description
            };
        }
    }
}