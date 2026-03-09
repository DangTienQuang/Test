using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FIt3d.DAL.Entities
{
    /// <summary>
    /// Subscription cho c? B2C (User) và B2B (Shop)
    /// </summary>
    public class Subscription : BaseEntity
    {
        public Guid UserId { get; set; }

        public Guid SubscriptionPlanId { get; set; }

        /// <summary>
        /// Ngày b?t ??u subscription
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Ngày k?t thúc subscription
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Tr?ng thái subscription
        /// </summary>
        public SubscriptionStatus Status { get; set; } = SubscriptionStatus.Active;

        /// <summary>
        /// S? ti?n ?ã thanh toán
        /// </summary>
        public decimal PaidAmount { get; set; }

        /// <summary>
        /// Mã giao d?ch thanh toán
        /// </summary>
        [MaxLength(100)]
        public string? PaymentTransactionId { get; set; }

        /// <summary>
        /// Ph??ng th?c thanh toán
        /// </summary>
        [MaxLength(50)]
        public string? PaymentMethod { get; set; }

        /// <summary>
        /// S? l??ng AI request ?ã s? d?ng trong tháng hi?n t?i
        /// </summary>
        public int AIRequestsUsedThisMonth { get; set; }

        /// <summary>
        /// Tháng reset AI request count
        /// </summary>
        public DateTime? AIRequestsResetDate { get; set; }

        /// <summary>
        /// S? l??ng model ?ã s? d?ng
        /// </summary>
        public int ModelsUsed { get; set; }

        /// <summary>
        /// T? ??ng gia h?n
        /// </summary>
        public bool AutoRenew { get; set; } = false;

        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual SubscriptionPlan SubscriptionPlan { get; set; } = null!;
        public virtual ICollection<AIUsageLog> AIUsageLogs { get; set; } = new List<AIUsageLog>();
        public virtual ICollection<Model> Models { get; set; } = new List<Model>();
    }

    public enum SubscriptionStatus
    {
        /// <summary>
        /// ?ang ch? thanh toán
        /// </summary>
        Pending = 0,

        /// <summary>
        /// ?ang ho?t ??ng
        /// </summary>
        Active = 1,

        /// <summary>
        /// ?ã h?t h?n
        /// </summary>
        Expired = 2,

        /// <summary>
        /// ?ã h?y
        /// </summary>
        Cancelled = 3,

        /// <summary>
        /// ?ã t?m d?ng
        /// </summary>
        Suspended = 4
    }
}
