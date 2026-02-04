using System;
using System.ComponentModel.DataAnnotations;

namespace FIt3d.DAL.Entities
{
    /// <summary>
    /// Log theo dõi vi?c s? d?ng AI
    /// </summary>
    public class AIUsageLog : BaseEntity
    {
        public Guid SubscriptionId { get; set; }

        /// <summary>
        /// Lo?i AI request
        /// </summary>
        public AIRequestType RequestType { get; set; }

        /// <summary>
        /// D? li?u input (JSON)
        /// </summary>
        public string? InputData { get; set; }

        /// <summary>
        /// D? li?u output (JSON)
        /// </summary>
        public string? OutputData { get; set; }

        /// <summary>
        /// Th?i gian x? lý (ms)
        /// </summary>
        public int ProcessingTimeMs { get; set; }

        /// <summary>
        /// Tr?ng thái request
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Thông báo l?i n?u có
        /// </summary>
        [MaxLength(500)]
        public string? ErrorMessage { get; set; }

        /// <summary>
        /// IP address c?a request
        /// </summary>
        [MaxLength(50)]
        public string? IpAddress { get; set; }

        // Navigation properties
        public virtual Subscription Subscription { get; set; } = null!;
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
