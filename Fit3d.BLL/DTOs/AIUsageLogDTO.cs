using FIt3d.DAL.Entities;

namespace Fit3d.BLL.DTOs
{
    /// <summary>
    /// Request DTO for logging AI chat usage from frontend
    /// </summary>
    public class CreateAIUsageLogRequest
    {
        /// <summary>
        /// Type of AI request
        /// </summary>
        public AIRequestType RequestType { get; set; }

        /// <summary>
        /// User's prompt/question sent to AI
        /// </summary>
        public string? UserPrompt { get; set; }

        /// <summary>
        /// AI's response message
        /// </summary>
        public string? AIResponse { get; set; }

        /// <summary>
        /// Additional input metadata (JSON)
        /// </summary>
        public string? InputData { get; set; }

        /// <summary>
        /// Additional output metadata (JSON)
        /// </summary>
        public string? OutputData { get; set; }

        /// <summary>
        /// Processing time in milliseconds
        /// </summary>
        public int ProcessingTimeMs { get; set; }

        /// <summary>
        /// Number of tokens used
        /// </summary>
        public int? TokensUsed { get; set; }

        /// <summary>
        /// Session ID for grouping conversations
        /// </summary>
        public string? SessionId { get; set; }

        /// <summary>
        /// Whether the request was successful
        /// </summary>
        public bool IsSuccess { get; set; } = true;

        /// <summary>
        /// Error message if failed
        /// </summary>
        public string? ErrorMessage { get; set; }
    }

    /// <summary>
    /// Response DTO for AI usage log
    /// </summary>
    public class AIUsageLogResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string? UserEmail { get; set; }
        public string? UserFullName { get; set; }
        public AIRequestType RequestType { get; set; }
        public string RequestTypeName => RequestType.ToString();
        public string? UserPrompt { get; set; }
        public string? AIResponse { get; set; }
        public string? InputData { get; set; }
        public string? OutputData { get; set; }
        public int ProcessingTimeMs { get; set; }
        public int? TokensUsed { get; set; }
        public string? SessionId { get; set; }
        public bool IsSuccess { get; set; }
        public string? ErrorMessage { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Summary of AI usage for a user
    /// </summary>
    public class AIUsageSummaryResponse
    {
        public Guid UserId { get; set; }
        public string? UserEmail { get; set; }
        public int TotalRequests { get; set; }
        public int SuccessfulRequests { get; set; }
        public int FailedRequests { get; set; }
        public int TotalTokensUsed { get; set; }
        public long TotalProcessingTimeMs { get; set; }
        public Dictionary<string, int> RequestsByType { get; set; } = new();
        public DateTime? LastUsageAt { get; set; }
    }

    /// <summary>
    /// Filter for querying AI usage logs
    /// </summary>
    public class AIUsageLogFilter
    {
        public AIRequestType? RequestType { get; set; }
        public bool? IsSuccess { get; set; }
        public string? SessionId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }

    /// <summary>
    /// Paginated result for AI usage logs
    /// </summary>
    public class AIUsageLogPagedResult
    {
        public List<AIUsageLogResponse> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);
        public bool HasNextPage => PageNumber < TotalPages;
        public bool HasPreviousPage => PageNumber > 1;
    }

    /// <summary>
    /// Response for AI request quota/remaining requests
    /// </summary>
    public class AIQuotaResponse
    {
        /// <summary>
        /// Whether user has an active subscription
        /// </summary>
        public bool HasActiveSubscription { get; set; }

        /// <summary>
        /// Subscription plan name (if any)
        /// </summary>
        public string? PlanName { get; set; }

        /// <summary>
        /// Maximum AI requests allowed per month
        /// </summary>
        public int MaxRequestsPerMonth { get; set; }

        /// <summary>
        /// Number of requests used this month
        /// </summary>
        public int RequestsUsedThisMonth { get; set; }

        /// <summary>
        /// Number of requests remaining this month
        /// </summary>
        public int RequestsRemaining => Math.Max(0, MaxRequestsPerMonth - RequestsUsedThisMonth);

        /// <summary>
        /// Whether user has AI feature enabled
        /// </summary>
        public bool HasAIFeature { get; set; }

        /// <summary>
        /// Whether user can make more AI requests
        /// </summary>
        public bool CanMakeRequest => HasActiveSubscription && HasAIFeature && RequestsRemaining > 0;

        /// <summary>
        /// Date when the request count resets
        /// </summary>
        public DateTime? ResetDate { get; set; }

        /// <summary>
        /// Subscription end date
        /// </summary>
        public DateTime? SubscriptionEndDate { get; set; }
    }
}
