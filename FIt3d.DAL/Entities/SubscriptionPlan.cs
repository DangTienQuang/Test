using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FIt3d.DAL.Enums;

namespace FIt3d.DAL.Entities
{
    /// <summary>
    /// ??nh ngh?a các gói subscription (B2C Stylist Pro, B2B Shop Plan)
    /// </summary>
    public class SubscriptionPlan : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        /// <summary>
        /// Lo?i gói: B2C ho?c B2B
        /// </summary>
        public PlanType PlanType { get; set; }

        /// <summary>
        /// Giá gói (VND)
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Th?i h?n gói tính b?ng ngày (30 = 1 tháng, 365 = 1 n?m)
        /// </summary>
        public int DurationInDays { get; set; }

        /// <summary>
        /// S? l??ng model có th? ch?nh s?a/l?u tr?
        /// </summary>
        public int MaxModels { get; set; }

        /// <summary>
        /// S? l?n ch?nh s?a t?i ?a cho m?i model
        /// </summary>
        public int MaxEditsPerModel { get; set; } = 10;

        /// <summary>
        /// S? l??ng AI request m?i tháng
        /// </summary>
        public int MaxAIRequestsPerMonth { get; set; }

        /// <summary>
        /// Cho phép s? d?ng AI ?? xu?t
        /// </summary>
        public bool HasAIFeature { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
    }
}
