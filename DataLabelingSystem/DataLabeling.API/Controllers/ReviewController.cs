using Microsoft.AspNetCore.Mvc;
using DataLabeling.Core.Interfaces;
using DataLabeling.Core.DTOs;

namespace DataLabeling.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public ReviewController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("pending")]
        public async Task<IActionResult> GetPendingReviews()
        {
            var tasks = await _taskService.GetSubmittedTasksAsync();
            return Ok(tasks);
        }

        [HttpPost("grade")]
        public async Task<IActionResult> ReviewTask([FromBody] ReviewTaskDto dto)
        {
            try
            {
                await _taskService.ReviewTaskAsync(dto);
                var statusMsg = dto.IsApproved ? "Đã duyệt" : "Đã trả về";
                return Ok($"Task {dto.TaskId}: {statusMsg}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}