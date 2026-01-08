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
    public class SystemConfigService : ISystemConfigService
    {
        private readonly AppDbContext _context;

        public SystemConfigService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SystemConfigDto>> GetAllConfigsAsync()
        {
            return await _context.Set<SystemConfig>()
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
            var config = await _context.Set<SystemConfig>().FirstOrDefaultAsync(c => c.Key == key);
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
            var config = await _context.Set<SystemConfig>().FirstOrDefaultAsync(c => c.Key == dto.Key);

            if (config == null)
            {
                // Create if not exists (optional behavior, but useful for initial setup)
                config = new SystemConfig
                {
                    Key = dto.Key,
                    Value = dto.Value,
                    Description = "Auto-created"
                };
                await _context.Set<SystemConfig>().AddAsync(config);
            }
            else
            {
                config.Value = dto.Value;
                _context.Set<SystemConfig>().Update(config);
            }

            await _context.SaveChangesAsync();

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