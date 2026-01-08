using DataLabeling.Core.DTOs;
using DataLabeling.Core.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLabeling.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<UserDto?> LoginAsync(LoginDto loginDto);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto?> GetUserByIdAsync(int id);
        Task<UserDto> UpdateUserAsync(int id, UpdateUserDto dto);
        Task DeleteUserAsync(int id);
        Task<IEnumerable<UserDto>> GetUsersByRoleAsync(UserRole role); 
    }
}