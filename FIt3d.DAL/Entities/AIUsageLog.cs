using System;
using System.ComponentModel.DataAnnotations;

namespace FIt3d.DAL.Entities
{
    /// <summary>
    /// Log theo dõi vi?c s? d?ng AI (tracked by user account)
    /// </summary>
    public class AIUsageLog : BaseEntity
    {
        /// <summary>
        /// User ID - tracking by account instead of IP
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Optional Subscription ID (if user has subscription)
        /// </summary>
        public Guid? SubscriptionId { get; set; }

        /// <summary>
        /// Lo?i AI request
        /// </summary>
        public AIRequestType RequestType { get; set; }

        /// <summary>
        /// User prompt/question sent to AI
        /// </summary>
        [MaxLength(2000)]
        public string? UserPrompt { get; set; }

        /// <summary>
        /// AI response message
        /// </summary>
        public string? AIResponse { get; set; }

        /// <summary>
        /// D? li?u input (JSON) - additional metadata
        /// </summary>
        public string? InputData { get; set; }

        /// <summary>
        /// D? li?u output (JSON) - additional metadata
        /// </summary>
        public string? OutputData { get; set; }

        /// <summary>
        /// Th?i gian x? lý (ms)
        /// </summary>
        public int ProcessingTimeMs { get; set; }

        /// <summary>
        /// Number of tokens used in request
        /// </summary>
        public int? TokensUsed { get; set; }

        /// <summary>
        /// Session ID for grouping conversations
        /// </summary>
        [MaxLength(100)]
        public string? SessionId { get; set; }

        /// <summary>
        /// Tr?ng thái request
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Thông báo l?i n?u có
        /// </summary>
        [MaxLength(500)]
        public string? ErrorMessage { get; set; }

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Subscription? Subscription { get; set; }
    }

    public enum AIRequestType
    {
        /// <summary>
        /// AI ?? xu?t màu s?c
        /// </summary>
        ColorSuggestion = 0,

        /// <summary>
        /// AI ?? xu?t phong cách ph?i ??
        /// </summary>
        StyleSuggestion = 1,

        /// <summary>
        /// AI phân tích body type
        /// </summary>
        BodyTypeAnalysis = 2,

        /// <summary>
        /// AI ph?i ?? t? ??ng
        /// </summary>
        AutoOutfitMatching = 3,

        /// <summary>
        /// AI ?? xu?t size
        /// </summary>
        SizeSuggestion = 4
    }
}
