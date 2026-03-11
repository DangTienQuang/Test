using Fit3d.BLL.DTOs;

namespace Fit3d.BLL.Interfaces
{
    public interface IAIUsageLogService
    {
        /// <summary>
        /// Log AI usage from frontend
        /// </summary>
        Task<AIUsageLogResponse> LogUsageAsync(Guid userId, CreateAIUsageLogRequest request);

        /// <summary>
        /// Get AI usage logs for a specific user
        /// </summary>
        Task<AIUsageLogPagedResult> GetUserLogsAsync(Guid userId, AIUsageLogFilter filter);

        /// <summary>
        /// Get usage summary for a specific user
        /// </summary>
        Task<AIUsageSummaryResponse> GetUserSummaryAsync(Guid userId);

        /// <summary>
        /// Get AI usage logs for a specific session
        /// </summary>
        Task<List<AIUsageLogResponse>> GetSessionLogsAsync(Guid userId, string sessionId);

        /// <summary>
        /// Get all AI usage logs (admin only)
        /// </summary>
        Task<AIUsageLogPagedResult> GetAllLogsAsync(AIUsageLogFilter filter);

        /// <summary>
        /// Get a specific log by ID
        /// </summary>
        Task<AIUsageLogResponse?> GetByIdAsync(Guid logId, Guid userId);

        /// <summary>
        /// Get AI request quota/remaining requests for a user
        /// </summary>
        Task<AIQuotaResponse> GetUserQuotaAsync(Guid userId);
    }
}
