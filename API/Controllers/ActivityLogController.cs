using BLL.Interfaces;
using Core.Constants;
using Microsoft.AspNetCore.Authorization;
using Core.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/activity-logs")]
    [ApiController]
    [Authorize]
    [Tags("6. Dispute & Logs")]
    public class ActivityLogController : ControllerBase
    {
        private readonly IActivityLogService _logService;

        public ActivityLogController(IActivityLogService logService)
        {
            _logService = logService;
        }

        /// <summary>
        /// Get system-wide activity logs.
        /// </summary>
        /// <remarks>
        /// Admin only. Retrieves general system events and user management logs.
        /// </remarks>
        /// <response code="200">System logs retrieved successfully.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpGet("system")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> GetSystemLogs()
        {
            var logs = await _logService.GetSystemLogsAsync();
            return Ok(logs);
        }

        /// <summary>
        /// Get activity logs specific to a project.
        /// </summary>
        /// <remarks>
        /// Admins and Managers can track events within their projects (e.g., data imports, task assignments).
        /// </remarks>
        /// <param name="projectId">The project ID.</param>
        /// <response code="200">Project logs retrieved successfully.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpGet("project/{projectId}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> GetProjectLogs(int projectId)
        {
            var logs = await _logService.GetProjectLogsAsync(projectId);
            return Ok(logs);
        }
    }
}