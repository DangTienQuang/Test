using Fit3d.BLL.DTOs;
using Fit3d.BLL.Interfaces;
using FIt3d.DAL.Data;
using FIt3d.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Fit3d.BLL.Services
{
    public class AIUsageLogService : IAIUsageLogService
    {
        private readonly Fit3dDbContext _context;

        public AIUsageLogService(Fit3dDbContext context)
        {
            _context = context;
        }

        public async Task<AIUsageLogResponse> LogUsageAsync(Guid userId, CreateAIUsageLogRequest request)
        {
            // Get active subscription for the user (if any)
            var subscription = await _context.Subscriptions
                .Where(s => s.UserId == userId && s.Status == SubscriptionStatus.Active && !s.IsDeleted && s.EndDate > DateTime.UtcNow)
                .OrderByDescending(s => s.EndDate)
                .FirstOrDefaultAsync();

            var log = new AIUsageLog
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                SubscriptionId = subscription?.Id,
                RequestType = request.RequestType,
                UserPrompt = request.UserPrompt,
                AIResponse = request.AIResponse,
                InputData = request.InputData,
                OutputData = request.OutputData,
                ProcessingTimeMs = request.ProcessingTimeMs,
                TokensUsed = request.TokensUsed,
                SessionId = request.SessionId,
                IsSuccess = request.IsSuccess,
                ErrorMessage = request.ErrorMessage,
                CreatedAt = DateTime.UtcNow
            };

            _context.AIUsageLogs.Add(log);
            await _context.SaveChangesAsync();

            var user = await _context.Users.FindAsync(userId);

            return MapToResponse(log, user);
        }

        public async Task<AIUsageLogPagedResult> GetUserLogsAsync(Guid userId, AIUsageLogFilter filter)
        {
            var query = _context.AIUsageLogs
                .Include(l => l.User)
                .Where(l => l.UserId == userId && !l.IsDeleted);

            query = ApplyFilters(query, filter);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(l => l.CreatedAt)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new AIUsageLogPagedResult
            {
                Items = items.Select(l => MapToResponse(l, l.User)).ToList(),
                TotalCount = totalCount,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }

        public async Task<AIUsageSummaryResponse> GetUserSummaryAsync(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);
            
            var logs = await _context.AIUsageLogs
                .Where(l => l.UserId == userId && !l.IsDeleted)
                .ToListAsync();

            var requestsByType = logs
                .GroupBy(l => l.RequestType)
                .ToDictionary(g => g.Key.ToString(), g => g.Count());

            return new AIUsageSummaryResponse
            {
                UserId = userId,
                UserEmail = user?.Email,
                TotalRequests = logs.Count,
                SuccessfulRequests = logs.Count(l => l.IsSuccess),
                FailedRequests = logs.Count(l => !l.IsSuccess),
                TotalTokensUsed = logs.Sum(l => l.TokensUsed ?? 0),
                TotalProcessingTimeMs = logs.Sum(l => l.ProcessingTimeMs),
                RequestsByType = requestsByType,
                LastUsageAt = logs.OrderByDescending(l => l.CreatedAt).FirstOrDefault()?.CreatedAt
            };
        }

        public async Task<List<AIUsageLogResponse>> GetSessionLogsAsync(Guid userId, string sessionId)
        {
            var logs = await _context.AIUsageLogs
                .Include(l => l.User)
                .Where(l => l.UserId == userId && l.SessionId == sessionId && !l.IsDeleted)
                .OrderBy(l => l.CreatedAt)
                .ToListAsync();

            return logs.Select(l => MapToResponse(l, l.User)).ToList();
        }

        public async Task<AIUsageLogPagedResult> GetAllLogsAsync(AIUsageLogFilter filter)
        {
            var query = _context.AIUsageLogs
                .Include(l => l.User)
                .Where(l => !l.IsDeleted);

            query = ApplyFilters(query, filter);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(l => l.CreatedAt)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToListAsync();

            return new AIUsageLogPagedResult
            {
                Items = items.Select(l => MapToResponse(l, l.User)).ToList(),
                TotalCount = totalCount,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize
            };
        }

        public async Task<AIUsageLogResponse?> GetByIdAsync(Guid logId, Guid userId)
        {
            var log = await _context.AIUsageLogs
                .Include(l => l.User)
                .FirstOrDefaultAsync(l => l.Id == logId && l.UserId == userId && !l.IsDeleted);

            return log != null ? MapToResponse(log, log.User) : null;
        }

        private static IQueryable<AIUsageLog> ApplyFilters(IQueryable<AIUsageLog> query, AIUsageLogFilter filter)
        {
            if (filter.RequestType.HasValue)
            {
                query = query.Where(l => l.RequestType == filter.RequestType.Value);
            }

            if (filter.IsSuccess.HasValue)
            {
                query = query.Where(l => l.IsSuccess == filter.IsSuccess.Value);
            }

            if (!string.IsNullOrEmpty(filter.SessionId))
            {
                query = query.Where(l => l.SessionId == filter.SessionId);
            }

            if (filter.FromDate.HasValue)
            {
                query = query.Where(l => l.CreatedAt >= filter.FromDate.Value);
            }

            if (filter.ToDate.HasValue)
            {
                query = query.Where(l => l.CreatedAt <= filter.ToDate.Value);
            }

            return query;
        }

        private static AIUsageLogResponse MapToResponse(AIUsageLog log, User? user)
        {
            return new AIUsageLogResponse
            {
                Id = log.Id,
                UserId = log.UserId,
                UserEmail = user?.Email,
                UserFullName = user?.FullName,
                RequestType = log.RequestType,
                UserPrompt = log.UserPrompt,
                AIResponse = log.AIResponse,
                InputData = log.InputData,
                OutputData = log.OutputData,
                ProcessingTimeMs = log.ProcessingTimeMs,
                TokensUsed = log.TokensUsed,
                SessionId = log.SessionId,
                IsSuccess = log.IsSuccess,
                ErrorMessage = log.ErrorMessage,
                CreatedAt = log.CreatedAt
            };
        }

        public async Task<AIQuotaResponse> GetUserQuotaAsync(Guid userId)
        {
            // Get active subscription for the user
            var subscription = await _context.Subscriptions
                .Include(s => s.SubscriptionPlan)
                .Where(s => s.UserId == userId && s.Status == SubscriptionStatus.Active && !s.IsDeleted && s.EndDate > DateTime.UtcNow)
                .OrderByDescending(s => s.EndDate)
                .FirstOrDefaultAsync();

            if (subscription == null)
            {
                return new AIQuotaResponse
                {
                    HasActiveSubscription = false,
                    PlanName = null,
                    MaxRequestsPerMonth = 0,
                    RequestsUsedThisMonth = 0,
                    HasAIFeature = false,
                    ResetDate = null,
                    SubscriptionEndDate = null
                };
            }

            var plan = subscription.SubscriptionPlan;

            // Check if we need to reset monthly counter
            var now = DateTime.UtcNow;
            var requestsUsed = subscription.AIRequestsUsedThisMonth;
            var resetDate = subscription.AIRequestsResetDate;

            // If reset date is in the past or not set, the counter should be considered reset
            if (resetDate == null || resetDate < now)
            {
                requestsUsed = 0;
                // Next reset date is first day of next month
                resetDate = new DateTime(now.Year, now.Month, 1).AddMonths(1);
            }

            return new AIQuotaResponse
            {
                HasActiveSubscription = true,
                PlanName = plan.Name,
                MaxRequestsPerMonth = plan.MaxAIRequestsPerMonth,
                RequestsUsedThisMonth = requestsUsed,
                HasAIFeature = plan.HasAIFeature,
                ResetDate = resetDate,
                SubscriptionEndDate = subscription.EndDate
            };
        }
    }
}
