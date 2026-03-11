using FIt3d.DAL.Enums;

namespace Fit3d.BLL.DTOs
{
    /// <summary>
    /// Response DTO for user's subscription status
    /// </summary>
    public class SubscriptionStatusResponse
    {
        /// <summary>
        /// Whether user has an active subscription
        /// </summary>
        public bool HasActiveSubscription { get; set; }

        /// <summary>
        /// Current subscription details (null if no active subscription)
        /// </summary>
        public SubscriptionDTO? CurrentSubscription { get; set; }

        /// <summary>
        /// Whether user is on a free tier
        /// </summary>
        public bool IsFreeTier => !HasActiveSubscription;
    }

    /// <summary>
    /// DTO for subscription details
    /// </summary>
    public class SubscriptionDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SubscriptionPlanId { get; set; }

        /// <summary>
        /// Subscription plan name
        /// </summary>
        public string PlanName { get; set; } = string.Empty;

        /// <summary>
        /// Plan type (B2C or B2B)
        /// </summary>
        public PlanType PlanType { get; set; }

        public string PlanTypeName => PlanType.ToString();

        /// <summary>
        /// Subscription start date
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Subscription end date
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Current subscription status
        /// </summary>
        public SubscriptionStatus Status { get; set; }

        public string StatusName => Status.ToString();

        /// <summary>
        /// Days remaining in subscription
        /// </summary>
        public int DaysRemaining => Math.Max(0, (EndDate.Date - DateTime.UtcNow.Date).Days);

        /// <summary>
        /// Whether subscription is expired
        /// </summary>
        public bool IsExpired => EndDate < DateTime.UtcNow;

        /// <summary>
        /// Amount paid for subscription
        /// </summary>
        public decimal PaidAmount { get; set; }

        /// <summary>
        /// Payment method used
        /// </summary>
        public string? PaymentMethod { get; set; }

        /// <summary>
        /// AI requests used this month
        /// </summary>
        public int AIRequestsUsedThisMonth { get; set; }

        /// <summary>
        /// Maximum AI requests allowed per month
        /// </summary>
        public int MaxAIRequestsPerMonth { get; set; }

        /// <summary>
        /// AI requests remaining this month
        /// </summary>
        public int AIRequestsRemaining => Math.Max(0, MaxAIRequestsPerMonth - AIRequestsUsedThisMonth);

        /// <summary>
        /// Number of models used
        /// </summary>
        public int ModelsUsed { get; set; }

        /// <summary>
        /// Maximum models allowed
        /// </summary>
        public int MaxModels { get; set; }

        /// <summary>
        /// Models remaining
        /// </summary>
        public int ModelsRemaining => Math.Max(0, MaxModels - ModelsUsed);

        /// <summary>
        /// Whether auto-renewal is enabled
        /// </summary>
        public bool AutoRenew { get; set; }

        /// <summary>
        /// Whether AI features are available
        /// </summary>
        public bool HasAIFeature { get; set; }

        /// <summary>
        /// Date when AI request count will reset
        /// </summary>
        public DateTime? AIRequestsResetDate { get; set; }

        /// <summary>
        /// Subscription plan details
        /// </summary>
        public SubscriptionPlanDTO? Plan { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    /// <summary>
    /// DTO for subscription plan details
    /// </summary>
    public class SubscriptionPlanDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public PlanType PlanType { get; set; }
        public string PlanTypeName => PlanType.ToString();
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public int MaxModels { get; set; }
        public int MaxEditsPerModel { get; set; }
        public int MaxAIRequestsPerMonth { get; set; }
        public bool HasAIFeature { get; set; }
        public bool IsActive { get; set; }
    }

    /// <summary>
    /// Response for listing all available subscription plans
    /// </summary>
    public class SubscriptionPlansResponse
    {
        public List<SubscriptionPlanDTO> Plans { get; set; } = new();
    }

    /// <summary>
    /// Response for subscription history
    /// </summary>
    public class SubscriptionHistoryResponse
    {
        public List<SubscriptionDTO> Subscriptions { get; set; } = new();
        public int TotalCount { get; set; }
    }
}
