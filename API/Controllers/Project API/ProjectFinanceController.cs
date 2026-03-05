using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/projects")]
    [Tags("3. Project Management")]
    [ApiController]
    [Authorize]
    public class ProjectFinanceController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectFinanceController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost("{projectId}/invoices")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GenerateInvoice(int projectId)
        {
            try
            {
                await _projectService.GenerateInvoicesAsync(projectId);
                return Ok(new { Message = "Invoices generated successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new Core.DTOs.Responses.ErrorResponse { Message = ex.Message });
            }
        }
    }
}