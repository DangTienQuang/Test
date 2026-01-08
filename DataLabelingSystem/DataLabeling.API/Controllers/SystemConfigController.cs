using DataLabeling.Core.DTOs;
using DataLabeling.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DataLabeling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemConfigController : ControllerBase
    {
        private readonly ISystemConfigService _configService;

        public SystemConfigController(ISystemConfigService configService)
        {
            _configService = configService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllConfigs()
        {
            var configs = await _configService.GetAllConfigsAsync();
            return Ok(configs);
        }

        [HttpGet("{key}")]
        public async Task<IActionResult> GetConfig(string key)
        {
            var config = await _configService.GetConfigByKeyAsync(key);
            if (config == null) return NotFound("Config not found");
            return Ok(config);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateConfig([FromBody] UpdateSystemConfigDto dto)
        {
            try
            {
                var config = await _configService.UpdateConfigAsync(dto);
                return Ok(config);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}