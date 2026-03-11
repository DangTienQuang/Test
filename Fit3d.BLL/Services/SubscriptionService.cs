using Fit3d.BLL.DTOs;
using Fit3d.BLL.Interfaces;
using FIt3d.DAL.Entities;
using FIt3d.DAL.Enums;
using FIt3d.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Fit3d.BLL.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IGenericRepository<Subscription> _subscriptionRepository;
        private readonly IGenericRepository<SubscriptionPlan> _planRepository;

        public SubscriptionService(
            IGenericRepository<Subscription> subscriptionRepository,
            IGenericRepository<SubscriptionPlan> planRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _planRepository = planRepository;
        }

        public async Task<SubscriptionStatusResponse> GetUserSubscriptionStatusAsync(Guid userId)
        {
            var activeSubscription = await _subscriptionRepository.SingleOrDefaultAsync(
                predicate: x => x.UserId == userId &&
                               !x.IsDeleted &&
                               x.Status == SubscriptionStatus.Active &&
                               x.EndDate >= DateTime.UtcNow,
                include: x => x.Include(s => s.SubscriptionPlan)
            );

            if (activeSubscription == null)
            {
                return new SubscriptionStatusResponse
                {
                    HasActiveSubscription = false,
                    CurrentSubscription = null
                };
            }

            return new SubscriptionStatusResponse
            {
                HasActiveSubscription = true,
                CurrentSubscription = ToDTO(activeSubscription)
            };
        }

        public async Task<SubscriptionHistoryResponse> GetUserSubscriptionHistoryAsync(Guid userId)
        {
            var subscriptions = await _subscriptionRepository.GetListAsync(
                predicate: x => x.UserId == userId && !x.IsDeleted,
                orderBy: x => x.OrderByDescending(s => s.CreatedAt),
                include: x => x.Include(s => s.SubscriptionPlan)
            );

            return new SubscriptionHistoryResponse
            {
                Subscriptions = subscriptions.Select(ToDTO).ToList(),
                TotalCount = subscriptions.Count
            };
        }

        public async Task<SubscriptionPlansResponse> GetAvailablePlansAsync()
        {
            var plans = await _planRepository.GetListAsync(
                predicate: x => x.IsActive && !x.IsDeleted,
                orderBy: x => x.OrderBy(p => p.Price)
            );

            return new SubscriptionPlansResponse
            {
                Plans = plans.Select(ToPlanDTO).ToList()
            };
        }

        public async Task<SubscriptionDTO?> GetSubscriptionByIdAsync(Guid subscriptionId, Guid userId)
        {
            var subscription = await _subscriptionRepository.SingleOrDefaultAsync(
                predicate: x => x.Id == subscriptionId && x.UserId == userId && !x.IsDeleted,
                include: x => x.Include(s => s.SubscriptionPlan)
            );

            return subscription == null ? null : ToDTO(subscription);
        }

        private static SubscriptionDTO ToDTO(Subscription entity)
        {
            var plan = entity.SubscriptionPlan;

            return new SubscriptionDTO
            {
                Id = entity.Id,
                UserId = entity.UserId,
                SubscriptionPlanId = entity.SubscriptionPlanId,
                PlanName = plan?.Name ?? string.Empty,
                PlanType = plan?.PlanType ?? PlanType.B2C_StylistPro,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Status = entity.Status,
                PaidAmount = entity.PaidAmount,
                PaymentMethod = entity.PaymentMethod,
                AIRequestsUsedThisMonth = entity.AIRequestsUsedThisMonth,
                MaxAIRequestsPerMonth = plan?.MaxAIRequestsPerMonth ?? 0,
                ModelsUsed = entity.ModelsUsed,
                MaxModels = plan?.MaxModels ?? 0,
                AutoRenew = entity.AutoRenew,
                HasAIFeature = plan?.HasAIFeature ?? false,
                AIRequestsResetDate = entity.AIRequestsResetDate,
                Plan = plan != null ? ToPlanDTO(plan) : null,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        private static SubscriptionPlanDTO ToPlanDTO(SubscriptionPlan entity)
        {
            return new SubscriptionPlanDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                PlanType = entity.PlanType,
                Price = entity.Price,
                DurationInDays = entity.DurationInDays,
                MaxModels = entity.MaxModels,
                MaxEditsPerModel = entity.MaxEditsPerModel,
                MaxAIRequestsPerMonth = entity.MaxAIRequestsPerMonth,
                HasAIFeature = entity.HasAIFeature,
                IsActive = entity.IsActive
            };
        }
    }
}
