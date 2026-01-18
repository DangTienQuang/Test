using DTOs.Requests;

namespace BLL.Interfaces
{
    public interface IReviewService
    {
        Task ReviewAssignmentAsync(string reviewerId, ReviewRequest request);
    }
}