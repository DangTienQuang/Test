using Microsoft.AspNetCore.Mvc;
using DataLabeling.Core.Interfaces;
using DataLabeling.Core.DTOs;
using System.Threading.Tasks;
using System;

namespace DataLabeling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectDto dto)
        {
            try
            {
                var result = await _projectService.CreateProjectAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("add-data")]
        public async Task<IActionResult> AddData([FromBody] AddDataItemDto dto)
        {
            try
            {
                var count = await _projectService.AddDataItemsAsync(dto);
                return Ok(new { Message = $"Đã thêm thành công {count} dữ liệu vào dự án." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("manager/{managerId}")]
        public async Task<IActionResult> GetManagerProjects(int managerId)
        {
            var projects = await _projectService.GetProjectsByManagerAsync(managerId);
            return Ok(projects);
        }

        [HttpGet("{projectId}/stats")]
        public async Task<IActionResult> GetProjectStats(int projectId)
        {
            try
            {
                var stats = await _projectService.GetProjectProgressAsync(projectId);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); 
            }
        }

        [HttpGet("{projectId}/export")]
        public async Task<IActionResult> ExportProject(int projectId)
        {
            try
            {
                var data = await _projectService.ExportApprovedDataAsync(projectId);

                var jsonOptions = new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                var jsonBytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(data, jsonOptions);

                return File(jsonBytes, "application/json", $"project_{projectId}_export.json");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}