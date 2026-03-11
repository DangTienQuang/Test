using Fit3d.BLL.Common;
using Fit3d.BLL.Configuration;
using Fit3d.BLL.DTOs;
using Fit3d.BLL.Interfaces;
using Fit3d.BLL.Utilities;
using FIt3d.DAL.Entities;
using FIt3d.DAL.Enums;
using FIt3d.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Net.payOS;
using Net.payOS.Types;
using PaymentTransaction = FIt3d.DAL.Entities.Transaction;

namespace Fit3d.BLL.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly PayOS _payOs;
        private readonly IUnitOfWork _unitOfWork;
        private readonly PayOsSetings _payOsSetings;
        private readonly IOrderService _orderService;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(IUnitOfWork unitOfWork, ILogger<PaymentService> logger, IOptions<PayOsSetings> payOsSetings, IOrderService orderService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _orderService = orderService;
            _payOsSetings = payOsSetings.Value;
            _payOs = new PayOS(_payOsSetings!.ClientId, _payOsSetings.ApiKey, _payOsSetings.ChecksumKey);
        }

        public async Task<ServiceResponse> CreatePayment(PaymentRequest requestBody, CancellationToken cancellationToken = default)
        {
            try
            {
                var order = await _unitOfWork.GetRepository<Order>()
                    .SingleOrDefaultAsync(
                        predicate: o => o.Id == requestBody.OrderId && !o.IsDeleted,
                        include: x => x.Include(o => o.OrderItems).ThenInclude(oi => oi.Product)
                    );

                if (order == null)
                {
                    _logger.LogError("Order not found with OrderId: {OrderId}", requestBody.OrderId);
                    return new ServiceResponse { Succeeded = false, Message = "Không tìm thấy đơn hàng!" };
                }

                if (order.CreatedAt < DateTime.UtcNow.AddMinutes(-20))
                {
                    _logger.LogError("Order expired with OrderId: {OrderId}", requestBody.OrderId);
                    order.PaymentStatus = PaymentStatus.Failed;
                    _unitOfWork.GetRepository<Order>().UpdateAsync(order);
                    await _unitOfWork.SaveChangesAsync();
                    return new ServiceResponse { Succeeded = false, Message = "Đơn hàng đã hết hạn! Vui lòng mua đơn hàng mới." };
                }

                if (order.PaymentStatus != PaymentStatus.Pending)
                {
                    _logger.LogError("Order status is not valid with OrderId: {OrderId}", requestBody.OrderId);
                    return new ServiceResponse { Succeeded = false, Message = "Trạng thái đơn hàng không hợp lệ!" };
                }

                var itemName = order.OrderItems.FirstOrDefault()?.Product?.Name ?? order.OrderNumber;
                var orderCode = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                var item = new ItemData(itemName, 1, (int)order.TotalAmount);
                var items = new List<ItemData> { item };
                var expiredAt = TimeConverter.GetCurrentVietNamTime()
                    .AddSeconds(_payOsSetings.ExpirationSeconds)
                    .ToUnixTimeSeconds();

                var data = new PaymentData(
                    orderCode: orderCode,
                    amount: item.price,
                    description: "Thanh toán đơn hàng",
                    items: items,
                    returnUrl: $"{_payOsSetings.OrderReturnUrl}?orderId={order.Id}",
                    cancelUrl: $"{_payOsSetings.OrderCancelUrl}?orderId={order.Id}",
                    expiredAt: expiredAt
                );
                var response = await _payOs.createPaymentLink(data);

                var transaction = new PaymentTransaction
                {
                    OrderId = order.Id,
                    UserId = order.UserId,
                    OrderCode = orderCode,
                    PaymentLinkId = response.paymentLinkId,
                    CheckoutUrl = response.checkoutUrl,
                    QrCode = response.qrCode,
                    Amount = order.TotalAmount,
                    Description = data.description,
                    TransactionStatus = TransactionStatus.Pending,
                    PaymentMethod = PaymentMethod.PayOs,
                };
                await _unitOfWork.GetRepository<PaymentTransaction>().InsertAsync(transaction);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Transaction created successfully with OrderId: {OrderId}", transaction.OrderId);
                return new ResponseData<CreatePaymentResult>
                {
                    Succeeded = true,
                    Message = "Tạo liên kết thanh toán thành công!",
                    Data = response
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating payment link for OrderId: {OrderId}", requestBody.OrderId);
                return new ServiceResponse { Succeeded = false, Message = "Lỗi khi tạo liên kết thanh toán!" };
            }
        }

        public async Task<ServiceResponse> PaymentReturn(Guid orderId, CancellationToken cancellationToken = default)
        {
            var transaction = await _unitOfWork.GetRepository<PaymentTransaction>()
                .SingleOrDefaultAsync(predicate: t => t.OrderId == orderId);

            if (transaction == null)
            {
                _logger.LogError("Order not found with OrderId: {OrderId}", orderId);
                return new ServiceResponse { Succeeded = false, Message = "Không tìm thấy đơn hàng!" };
            }

            if (transaction.TransactionStatus != TransactionStatus.Pending)
            {
                _logger.LogError("Transaction status not valid with {OrderId}", orderId);
                return new ServiceResponse { Succeeded = false, Message = "Trạng thái giao dịch không hợp lệ!" };
            }

            try
            {
                var orderResponse = await _orderService.UpdateOrderToReturn(transaction.OrderId, cancellationToken);
                if (!orderResponse.Succeeded)
                {
                    transaction.TransactionStatus = TransactionStatus.Fail;
                    _unitOfWork.GetRepository<PaymentTransaction>().UpdateAsync(transaction);
                    await _unitOfWork.SaveChangesAsync();
                    _logger.LogInformation("Payment return fail with OrderId: {OrderId}", transaction.OrderId);
                    return new ServiceResponse { Succeeded = false, Message = "Giao dịch thất bại!" };
                }

                transaction.TransactionStatus = TransactionStatus.Return;
                _unitOfWork.GetRepository<PaymentTransaction>().UpdateAsync(transaction);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Payment return successfully with OrderId: {OrderId}", transaction.OrderId);
                return new ServiceResponse { Succeeded = true, Message = "Giao dịch thành công!" };
            }
            catch (Exception ex)
            {
                transaction.TransactionStatus = TransactionStatus.Fail;
                _unitOfWork.GetRepository<PaymentTransaction>().UpdateAsync(transaction);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogError(ex, "Payment return fail with OrderId: {OrderId}", transaction.OrderId);
                return new ServiceResponse { Succeeded = false, Message = "Giao dịch thất bại!" };
            }
        }

        public async Task<ServiceResponse> PaymentCancel(Guid orderId, CancellationToken cancellationToken = default)
        {
            var transaction = await _unitOfWork.GetRepository<PaymentTransaction>()
                .SingleOrDefaultAsync(predicate: t => t.OrderId == orderId);

            if (transaction == null)
            {
                _logger.LogError("Order not found with OrderId: {OrderId}", orderId);
                return new ServiceResponse { Succeeded = false, Message = "Không tìm thấy đơn hàng!" };
            }

            if (transaction.TransactionStatus != TransactionStatus.Pending)
            {
                _logger.LogError("Transaction status not valid with {OrderId}", orderId);
                return new ServiceResponse { Succeeded = false, Message = "Trạng thái giao dịch không hợp lệ!" };
            }

            try
            {
                var orderResponse = await _orderService.UpdateOrderToCancel(transaction.OrderId, cancellationToken);
                if (!orderResponse.Succeeded)
                {
                    transaction.TransactionStatus = TransactionStatus.Fail;
                    _unitOfWork.GetRepository<PaymentTransaction>().UpdateAsync(transaction);
                    await _unitOfWork.SaveChangesAsync();
                    _logger.LogInformation("Payment cancel fail with OrderId: {OrderId}", transaction.OrderId);
                    return new ServiceResponse { Succeeded = false, Message = "Giao dịch thất bại!" };
                }

                transaction.TransactionStatus = TransactionStatus.Cancel;
                _unitOfWork.GetRepository<PaymentTransaction>().UpdateAsync(transaction);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogInformation("Payment cancel successfully with OrderId: {OrderId}", transaction.OrderId);
                return new ServiceResponse { Succeeded = true, Message = "Hủy giao dịch thành công!" };
            }
            catch (Exception ex)
            {
                transaction.TransactionStatus = TransactionStatus.Fail;
                _unitOfWork.GetRepository<PaymentTransaction>().UpdateAsync(transaction);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogError(ex, "Payment cancel fail with OrderId: {OrderId}", transaction.OrderId);
                return new ServiceResponse { Succeeded = false, Message = "Giao dịch thất bại!" };
            }
        }

        public async Task<ServiceResponse> GetSubscriptionPlansByType(PlanType planType, CancellationToken cancellationToken = default)
        {
            try
            {
                var plans = await _unitOfWork.GetRepository<SubscriptionPlan>()
                    .GetListAsync(predicate: p => p.PlanType == planType && p.IsActive);

                var result = plans.Select(p => new SubscriptionPlanResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    PlanType = p.PlanType,
                    Price = p.Price,
                    DurationInDays = p.DurationInDays,
                    MaxModels = p.MaxModels,
                    MaxEditsPerModel = p.MaxEditsPerModel,
                    MaxAIRequestsPerMonth = p.MaxAIRequestsPerMonth,
                    HasAIFeature = p.HasAIFeature,
                }).ToList();

                return new ResponseData<List<SubscriptionPlanResponse>>
                {
                    Succeeded = true,
                    Message = "Lấy danh sách gói thành công!",
                    Data = result
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting subscription plans for PlanType: {PlanType}", planType);
                return new ServiceResponse { Succeeded = false, Message = "Lỗi khi lấy danh sách gói subscription!" };
            }
        }

        public async Task<ServiceResponse> CreateSubscriptionPayment(SubscriptionPaymentRequest request, CancellationToken cancellationToken = default)
        {
            try
            {
                var plan = await _unitOfWork.GetRepository<SubscriptionPlan>()
                    .SingleOrDefaultAsync(predicate: p => p.Id == request.SubscriptionPlanId && p.IsActive);

                if (plan == null)
                {
                    _logger.LogError("Subscription plan not found: {PlanId}", request.SubscriptionPlanId);
                    return new ServiceResponse { Succeeded = false, Message = "Không tìm thấy gói subscription!" };
                }

                if (plan.PlanType != request.PlanType)
                {
                    _logger.LogError("PlanType mismatch: requested {Requested}, actual {Actual}", request.PlanType, plan.PlanType);
                    var expectedType = request.PlanType == PlanType.B2C_StylistPro ? "Gói cá nhân (Stylist Pro)" : "Gói shop (B2B)";
                    return new ServiceResponse { Succeeded = false, Message = $"Gói được chọn không thuộc loại {expectedType}!" };
                }

                var user = await _unitOfWork.GetRepository<User>().GetByIdAsync(request.UserId);
                if (user == null || user.IsDeleted)
                {
                    _logger.LogError("User not found: {UserId}", request.UserId);
                    return new ServiceResponse { Succeeded = false, Message = "Không tìm thấy người dùng!" };
                }

                var subscription = new Subscription
                {
                    UserId = request.UserId,
                    SubscriptionPlanId = plan.Id,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddDays(plan.DurationInDays),
                    Status = SubscriptionStatus.Pending,
                    PaidAmount = plan.Price,
                    PaymentMethod = "PayOS",
                };
                await _unitOfWork.GetRepository<Subscription>().InsertAsync(subscription);
                await _unitOfWork.SaveChangesAsync();

                var orderCode = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
                var description = plan.Name.Length > 25 ? plan.Name[..25] : plan.Name;
                var item = new ItemData(plan.Name, 1, (int)plan.Price);
                var items = new List<ItemData> { item };
                var expiredAt = TimeConverter.GetCurrentVietNamTime()
                    .AddSeconds(_payOsSetings.ExpirationSeconds)
                    .ToUnixTimeSeconds();

                var data = new PaymentData(
                    orderCode: orderCode,
                    amount: item.price,
                    description: description,
                    items: items,
                    returnUrl: $"{_payOsSetings.SubscriptionReturnUrl}?subscriptionId={subscription.Id}",
                    cancelUrl: $"{_payOsSetings.SubscriptionCancelUrl}?subscriptionId={subscription.Id}",
                    expiredAt: expiredAt
                );
                var response = await _payOs.createPaymentLink(data);

                subscription.PaymentTransactionId = response.paymentLinkId;
                _unitOfWork.GetRepository<Subscription>().UpdateAsync(subscription);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Subscription payment created for UserId: {UserId}, PlanId: {PlanId}", request.UserId, plan.Id);
                return new ResponseData<CreatePaymentResult>
                {
                    Succeeded = true,
                    Message = "Tạo liên kết thanh toán gói subscription thành công!",
                    Data = response
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating subscription payment for UserId: {UserId}", request.UserId);
                return new ServiceResponse { Succeeded = false, Message = "Lỗi khi tạo liên kết thanh toán subscription!" };
            }
        }

        public async Task<ServiceResponse> SubscriptionPaymentReturn(Guid subscriptionId, CancellationToken cancellationToken = default)
        {
            var subscription = await _unitOfWork.GetRepository<Subscription>()
                .SingleOrDefaultAsync(
                    predicate: s => s.Id == subscriptionId,
                    include: x => x.Include(s => s.SubscriptionPlan)
                );

            if (subscription == null)
            {
                _logger.LogError("Subscription not found: {SubscriptionId}", subscriptionId);
                return new ServiceResponse { Succeeded = false, Message = "Không tìm thấy gói subscription!" };
            }

            if (subscription.Status != SubscriptionStatus.Pending)
            {
                _logger.LogError("Subscription status not valid: {SubscriptionId}", subscriptionId);
                return new ServiceResponse { Succeeded = false, Message = "Trạng thái subscription không hợp lệ!" };
            }

            try
            {
                var durationInDays = subscription.SubscriptionPlan.DurationInDays;
                subscription.SubscriptionPlan = null!;
                subscription.Status = SubscriptionStatus.Active;
                subscription.StartDate = DateTime.UtcNow;
                subscription.EndDate = DateTime.UtcNow.AddDays(durationInDays);
                subscription.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.GetRepository<Subscription>().UpdateAsync(subscription);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Subscription payment return successfully: {SubscriptionId}", subscriptionId);
                return new ServiceResponse { Succeeded = true, Message = "Thanh toán gói subscription thành công!" };
            }
            catch (Exception ex)
            {
                subscription.SubscriptionPlan = null!;
                subscription.Status = SubscriptionStatus.Cancelled;
                subscription.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.GetRepository<Subscription>().UpdateAsync(subscription);
                await _unitOfWork.SaveChangesAsync();
                _logger.LogError(ex, "Subscription payment return fail: {SubscriptionId}", subscriptionId);
                return new ServiceResponse { Succeeded = false, Message = "Thanh toán gói subscription thất bại!" };
            }
        }

        public async Task<ServiceResponse> SubscriptionPaymentCancel(Guid subscriptionId, CancellationToken cancellationToken = default)
        {
            var subscription = await _unitOfWork.GetRepository<Subscription>()
                .SingleOrDefaultAsync(predicate: s => s.Id == subscriptionId);

            if (subscription == null)
            {
                _logger.LogError("Subscription not found: {SubscriptionId}", subscriptionId);
                return new ServiceResponse { Succeeded = false, Message = "Không tìm thấy gói subscription!" };
            }

            if (subscription.Status != SubscriptionStatus.Pending)
            {
                _logger.LogError("Subscription status not valid: {SubscriptionId}", subscriptionId);
                return new ServiceResponse { Succeeded = false, Message = "Trạng thái subscription không hợp lệ!" };
            }

            try
            {
                subscription.Status = SubscriptionStatus.Cancelled;
                subscription.UpdatedAt = DateTime.UtcNow;
                _unitOfWork.GetRepository<Subscription>().UpdateAsync(subscription);
                await _unitOfWork.SaveChangesAsync();

                _logger.LogInformation("Subscription payment cancelled: {SubscriptionId}", subscriptionId);
                return new ServiceResponse { Succeeded = true, Message = "Hủy thanh toán gói subscription thành công!" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error cancelling subscription payment: {SubscriptionId}", subscriptionId);
                return new ServiceResponse { Succeeded = false, Message = "Lỗi khi hủy thanh toán subscription!" };
            }
        }
    }
}
