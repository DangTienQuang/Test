using BLL.Interfaces;
using Core.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using Core.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/projects")]
    [ApiController]
    [Authorize]
    [Tags("3. Project Management")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// Create a new project.
        /// </summary>
        /// <remarks>
        /// Manager and Admin roles only.
        /// </remarks>
        /// <param name="request">The project creation request payload.</param>
        /// <response code="200">Project created successfully.</response>
        /// <response code="400">Creation failed.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpPost]
        [Authorize(Roles = "Manager,Admin")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequest request)
        {
            var managerId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(managerId)) return Unauthorized(new ErrorResponse { StatusCode = 401, Message = "User is not authenticated." });

            try
            {
                var result = await _projectService.CreateProjectAsync(managerId, request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }

        /// <summary>
        /// Update an existing project.
        /// </summary>
        /// <remarks>
        /// Manager and Admin roles only.
        /// </remarks>
        /// <param name="id">The project ID.</param>
        /// <param name="request">The project update payload.</param>
        /// <response code="200">Project updated successfully.</response>
        /// <response code="400">Update failed.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpPut("{id}")]
        [Authorize(Roles = "Manager,Admin")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] UpdateProjectRequest request)
        {
            try
            {
                await _projectService.UpdateProjectAsync(id, request);
                return Ok(new { Message = "Project updated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get details of a specific project.
        /// </summary>
        /// <param name="id">The project ID.</param>
        /// <response code="200">Project details retrieved successfully.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="401">User is not authorized.</response>
        /// <response code="404">Project not found.</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "Manager,Admin,Annotator,Reviewer")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        [ProducesResponseType(typeof(ErrorResponse), 404)]
        public async Task<IActionResult> GetProjectDetails(int id)
        {
            try
            {
                var project = await _projectService.GetProjectDetailsAsync(id);
                if (project == null) return NotFound(new ErrorResponse { StatusCode = 404, Message = "Project not found." });
                return Ok(project);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }

        /// <summary>
        /// Get all projects for a specific manager.
        /// </summary>
        /// <remarks>
        /// Manager and Admin roles only.
        /// </remarks>
        /// <param name="managerId">The manager's ID.</param>
        /// <response code="200">List of projects retrieved successfully.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpGet("manager/{managerId}")]
        [Authorize(Roles = "Manager,Admin")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> GetProjectsByManager(string managerId)
        {
            try
            {
                var projects = await _projectService.GetProjectsByManagerAsync(managerId);
                return Ok(projects);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }

        /// <summary>
        /// Delete a project.
        /// </summary>
        /// <remarks>
        /// Manager and Admin roles only.
        /// </remarks>
        /// <param name="id">The project ID to delete.</param>
        /// <response code="200">Project deleted successfully.</response>
        /// <response code="400">Deletion failed.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager,Admin")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> DeleteProject(int id)
        {
            try
            {
                await _projectService.DeleteProjectAsync(id);
                return Ok(new { Message = "Project deleted successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }
    }
}