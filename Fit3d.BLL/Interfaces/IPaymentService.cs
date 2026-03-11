using Fit3d.BLL.Common;
using Fit3d.BLL.DTOs;
using FIt3d.DAL.Enums;

namespace Fit3d.BLL.Interfaces
{
    public interface IPaymentService
    {
        Task<ServiceResponse> CreatePayment(PaymentRequest requestBody, CancellationToken cancellationToken = default);
        Task<ServiceResponse> PaymentReturn(Guid orderId, CancellationToken cancellationToken = default);
        Task<ServiceResponse> PaymentCancel(Guid orderId, CancellationToken cancellationToken = default);

        Task<ServiceResponse> GetSubscriptionPlansByType(PlanType planType, CancellationToken cancellationToken = default);
        Task<ServiceResponse> CreateSubscriptionPayment(SubscriptionPaymentRequest request, CancellationToken cancellationToken = default);
        Task<ServiceResponse> SubscriptionPaymentReturn(Guid subscriptionId, CancellationToken cancellationToken = default);
        Task<ServiceResponse> SubscriptionPaymentCancel(Guid subscriptionId, CancellationToken cancellationToken = default);
    }
}
