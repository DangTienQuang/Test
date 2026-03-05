using BLL.Interfaces;
using Core.Constants;
using Core.DTOs.Requests;
using Microsoft.AspNetCore.Authorization;
using Core.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    [Route("api/disputes")]
    [ApiController]
    [Authorize]
    [Tags("6. Dispute & Logs")]
    public class DisputeController : ControllerBase
    {
        private readonly IDisputeService _disputeService;

        public DisputeController(IDisputeService disputeService)
        {
            _disputeService = disputeService;
        }

        /// <summary>
        /// Create a new dispute for a rejected task.
        /// </summary>
        /// <remarks>
        /// Annotators can open a dispute if they disagree with a Reviewer's rejection.
        /// </remarks>
        /// <param name="request">Dispute details including the Assignment ID and reason.</param>
        /// <response code="200">Dispute submitted successfully.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpPost]
        [Authorize(Roles = "Annotator")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> CreateDispute([FromBody] CreateDisputeRequest request)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            await _disputeService.CreateDisputeAsync(userId, request);
            return Ok(new { Message = "Dispute submitted successfully." });
        }

        /// <summary>
        /// Resolve an existing dispute.
        /// </summary>
        /// <remarks>
        /// Managers and Admins can resolve disputes by deciding in favor of the Annotator or Reviewer.
        /// </remarks>
        /// <param name="request">Resolution details including the Dispute ID and final decision.</param>
        /// <response code="200">Dispute resolved successfully.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="401">User is not authorized.</response>
        [HttpPost("resolve")]
        [Authorize(Roles = "Manager,Admin")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> ResolveDispute([FromBody] ResolveDisputeRequest request)
        {
            await _disputeService.ResolveDisputeAsync(request);
            return Ok(new { Message = "Dispute resolved." });
        }

        /// <summary>
        /// Get a list of disputes filtered by project.
        /// </summary>
        /// <remarks>
        /// Annotators see their own disputes. Managers and Admins see all disputes in the project.
        /// </remarks>
        /// <param name="projectId">The ID of the project to filter disputes.</param>
        /// <response code="200">Disputes retrieved successfully.</response>
        /// <response code="400">Invalid request.</response>
        /// <response code="401">User is not authenticated.</response>
        [HttpGet]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 401)]
        public async Task<IActionResult> GetDisputes([FromQuery] int projectId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;

            var disputes = await _disputeService.GetDisputesAsync(projectId, userId, role);
            return Ok(disputes);
        }
    }
}