using FIt3d.DAL.Enums;

namespace Fit3d.BLL.DTOs
{
    public class PaymentRequest
    {
        public Guid OrderId { get; set; }
    }

    public class SubscriptionPaymentRequest
    {
        public Guid UserId { get; set; }

        /// <summary>
        /// 0 = B2C_StylistPro (Gói cá nhân), 1 = B2B_Shop (Gói shop)
        /// </summary>
        public PlanType PlanType { get; set; }

        public Guid SubscriptionPlanId { get; set; }
    }

    public class SubscriptionPlanResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public PlanType PlanType { get; set; }
        public decimal Price { get; set; }
        public int DurationInDays { get; set; }
        public int MaxModels { get; set; }
        public int MaxEditsPerModel { get; set; }
        public int MaxAIRequestsPerMonth { get; set; }
        public bool HasAIFeature { get; set; }
    }
}
