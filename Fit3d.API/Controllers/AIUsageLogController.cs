using Fit3d.BLL.DTOs;
using Fit3d.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fit3d.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AIUsageLogController : ControllerBase
    {
        private readonly IAIUsageLogService _aiUsageLogService;

        public AIUsageLogController(IAIUsageLogService aiUsageLogService)
        {
            _aiUsageLogService = aiUsageLogService;
        }

        /// <summary>
        /// Log AI usage from frontend (Google AI Studio chatbot)
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(AIUsageLogResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> LogUsage([FromBody] CreateAIUsageLogRequest request)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var result = await _aiUsageLogService.LogUsageAsync(userId.Value, request);
            return Ok(result);
        }

        /// <summary>
        /// Get AI usage logs for current user
        /// </summary>
        [HttpGet("my-logs")]
        [ProducesResponseType(typeof(AIUsageLogPagedResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetMyLogs([FromQuery] AIUsageLogFilter filter)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var result = await _aiUsageLogService.GetUserLogsAsync(userId.Value, filter);
            return Ok(result);
        }

        /// <summary>
        /// Get AI usage summary for current user
        /// </summary>
        [HttpGet("my-summary")]
        [ProducesResponseType(typeof(AIUsageSummaryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetMySummary()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var result = await _aiUsageLogService.GetUserSummaryAsync(userId.Value);
            return Ok(result);
        }

        /// <summary>
        /// Get AI usage logs for a specific session
        /// </summary>
        [HttpGet("session/{sessionId}")]
        [ProducesResponseType(typeof(List<AIUsageLogResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetSessionLogs(string sessionId)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var result = await _aiUsageLogService.GetSessionLogsAsync(userId.Value, sessionId);
            return Ok(result);
        }

        /// <summary>
        /// Get a specific AI usage log by ID
        /// </summary>
        [HttpGet("{logId}")]
        [ProducesResponseType(typeof(AIUsageLogResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetById(Guid logId)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var result = await _aiUsageLogService.GetByIdAsync(logId, userId.Value);
            if (result == null)
            {
                return NotFound(new { message = "Log not found" });
            }

            return Ok(result);
        }

        /// <summary>
        /// Get all AI usage logs (Admin only)
        /// </summary>
        [HttpGet("admin/all")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(typeof(AIUsageLogPagedResult), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllLogs([FromQuery] AIUsageLogFilter filter)
        {
            var result = await _aiUsageLogService.GetAllLogsAsync(filter);
            return Ok(result);
        }

        /// <summary>
        /// Get AI request quota/remaining requests for current user
        /// </summary>
        [HttpGet("quota")]
        [ProducesResponseType(typeof(AIQuotaResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetQuota()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return Unauthorized(new { message = "User not authenticated" });
            }

            var result = await _aiUsageLogService.GetUserQuotaAsync(userId.Value);
            return Ok(result);
        }

        private Guid? GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userIdClaim, out var userId))
            {
                return userId;
            }
            return null;
        }
    }
}
