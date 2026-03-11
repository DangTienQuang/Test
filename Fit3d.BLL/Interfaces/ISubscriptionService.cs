using Fit3d.BLL.DTOs;

namespace Fit3d.BLL.Interfaces
{
    public interface ISubscriptionService
    {
        /// <summary>
        /// Get current subscription status for a user
        /// </summary>
        Task<SubscriptionStatusResponse> GetUserSubscriptionStatusAsync(Guid userId);

        /// <summary>
        /// Get subscription history for a user
        /// </summary>
        Task<SubscriptionHistoryResponse> GetUserSubscriptionHistoryAsync(Guid userId);

        /// <summary>
        /// Get all available subscription plans
        /// </summary>
        Task<SubscriptionPlansResponse> GetAvailablePlansAsync();

        /// <summary>
        /// Get a specific subscription by ID
        /// </summary>
        Task<SubscriptionDTO?> GetSubscriptionByIdAsync(Guid subscriptionId, Guid userId);
    }
}
