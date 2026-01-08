using Microsoft.AspNetCore.Mvc;
using DataLabeling.Core.Interfaces;
using DataLabeling.Core.DTOs;

namespace DataLabeling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpPost("assign")]
        public async Task<IActionResult> AssignTasks([FromBody] AssignTaskDto dto)
        {
            try
            {
                await _taskService.AssignTasksAsync(dto);
                return Ok("Phân công thành công.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("my-tasks/{annotatorId}")]
        public async Task<IActionResult> GetMyTasks(int annotatorId)
        {
            var tasks = await _taskService.GetTasksByAnnotatorAsync(annotatorId);
            return Ok(tasks);
        }
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitLabel([FromBody] SubmitLabelDto dto)
        {
            try
            {
                await _taskService.SubmitLabelAsync(dto);
                return Ok("Đã nộp kết quả gán nhãn.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}