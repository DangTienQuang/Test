using Fit3d.BLL.DTOs;
using Fit3d.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Fit3d.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        /// <summary>
        /// Get current user's subscription status
        /// </summary>
        [HttpGet("status")]
        [Authorize]
        [ProducesResponseType(typeof(SubscriptionStatusResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCurrentUserSubscriptionStatus()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var result = await _subscriptionService.GetUserSubscriptionStatusAsync(userId.Value);
            return Ok(result);
        }

        /// <summary>
        /// Get current user's subscription history
        /// </summary>
        [HttpGet("history")]
        [Authorize]
        [ProducesResponseType(typeof(SubscriptionHistoryResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetCurrentUserSubscriptionHistory()
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var result = await _subscriptionService.GetUserSubscriptionHistoryAsync(userId.Value);
            return Ok(result);
        }

        /// <summary>
        /// Get all available subscription plans
        /// </summary>
        [HttpGet("plans")]
        [ProducesResponseType(typeof(SubscriptionPlansResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAvailablePlans()
        {
            var result = await _subscriptionService.GetAvailablePlansAsync();
            return Ok(result);
        }

        /// <summary>
        /// Get a specific subscription by ID
        /// </summary>
        [HttpGet("{id:guid}")]
        [Authorize]
        [ProducesResponseType(typeof(SubscriptionDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetSubscriptionById(Guid id)
        {
            var userId = GetCurrentUserId();
            if (userId == null)
            {
                return Unauthorized();
            }

            var result = await _subscriptionService.GetSubscriptionByIdAsync(id, userId.Value);
            if (result == null)
            {
                return NotFound(new { message = "Subscription not found" });
            }

            return Ok(result);
        }

        private Guid? GetCurrentUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
            {
                return null;
            }
            return userId;
        }
    }
}
