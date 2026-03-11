using Fit3d.BLL.DTOs;
using FIt3d.DAL.Entities;

namespace Fit3d.BLL.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request, string? ipAddress = null);
        Task<LoginResponse> RegisterAsync(RegisterRequest request, string? ipAddress = null);
        Task<RefreshTokenResponse> RefreshTokenAsync(string token, string? ipAddress = null);
        Task<bool> RevokeTokenAsync(string token, string? ipAddress = null);
        Task<User?> GetUserByIdAsync(Guid userId);
    }
}
