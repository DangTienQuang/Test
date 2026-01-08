using DataLabeling.Core.DTOs;
using DataLabeling.Core.Entities;
using DataLabeling.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataLabeling.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<UserDto>> GetUsersByRoleAsync(DataLabeling.Core.Enums.UserRole role)
        {
            var users = await _unitOfWork.Repository<User>().FindAsync(u => u.Role == role);

            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                FullName = u.FullName,
                Email = u.Email,
                Role = u.Role.ToString()
            });
        }
        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _unitOfWork.Repository<User>().GetAllAsync();

            return users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                FullName = u.FullName,
                Email = u.Email,
                Role = u.Role.ToString()
            });
        }

        public async Task<UserDto?> LoginAsync(LoginDto loginDto)
        {
            var hashedPassword = HashPassword(loginDto.Password);

            var users = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.Username == loginDto.Username && u.PasswordHash == hashedPassword);

            var user = users.FirstOrDefault();

            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            var existingUsers = await _unitOfWork.Repository<User>()
                .FindAsync(u => u.Username == registerDto.Username);

            if (existingUsers.Any())
            {
                throw new Exception("Username đã tồn tại.");
            }

            var newUser = new User
            {
                Username = registerDto.Username,
                PasswordHash = HashPassword(registerDto.Password),
                FullName = registerDto.FullName,
                Email = registerDto.Email,
                Role = registerDto.Role
            };

            await _unitOfWork.Repository<User>().AddAsync(newUser);
            await _unitOfWork.CompleteAsync();

            return new UserDto
            {
                Id = newUser.Id,
                Username = newUser.Username,
                FullName = newUser.FullName,
                Email = newUser.Email,
                Role = newUser.Role.ToString()
            };
        }

        private string HashPassword(string password)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(password);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return Convert.ToHexString(hashBytes);
            }
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.Repository<User>().GetByIdAsync(id);
            if (user == null) return null;

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }

        public async Task<UserDto> UpdateUserAsync(int id, UpdateUserDto dto)
        {
            var user = await _unitOfWork.Repository<User>().GetByIdAsync(id);
            if (user == null) throw new Exception("Người dùng không tồn tại.");

            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.Role = dto.Role;

            _unitOfWork.Repository<User>().Update(user);
            await _unitOfWork.CompleteAsync();

            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToString()
            };
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _unitOfWork.Repository<User>().GetByIdAsync(id);
            if (user == null) throw new Exception("Người dùng không tồn tại.");
            _unitOfWork.Repository<User>().Remove(user);

            await _unitOfWork.CompleteAsync();
        }
    }
}