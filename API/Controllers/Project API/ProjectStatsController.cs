using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Core.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    [Authorize]
    [Tags("3. Project Management")]
    public class ProjectStatsController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectStatsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// Get comprehensive statistics for a specific project.
        /// </summary>
        /// <param name="projectId">The project ID.</param>
        /// <response code="200">Statistics retrieved successfully.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpGet("{projectId}/statistics")]
        [Authorize(Roles = "Manager,Admin,Reviewer")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> GetProjectStatistics(int projectId)
        {
            try
            {
                var stats = await _projectService.GetProjectStatisticsAsync(projectId);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get high-level statistics for a manager across all their projects.
        /// </summary>
        /// <param name="managerId">The manager's ID.</param>
        /// <response code="200">Statistics retrieved successfully.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpGet("manager/{managerId}/statistics")]
        [Authorize(Roles = "Manager,Admin")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> GetManagerStats(string managerId)
        {
            try
            {
                var stats = await _projectService.GetManagerStatsAsync(managerId);
                return Ok(stats);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }
    }
}