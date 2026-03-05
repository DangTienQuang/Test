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
    public class ProjectFinanceController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectFinanceController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        /// <summary>
        /// Generate invoices for a project.
        /// </summary>
        /// <remarks>
        /// Admin only.
        /// </remarks>
        /// <param name="projectId">The project ID.</param>
        /// <response code="200">Invoices generated successfully.</response>
        /// <response code="400">Generation failed.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpPost("{projectId}/invoices")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> GenerateInvoice(int projectId)
        {
            try
            {
                await _projectService.GenerateInvoicesAsync(projectId);
                return Ok(new { Message = "Invoices generated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResponse { StatusCode = 400, Message = ex.Message });
            }
        }
    }
}