using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FIt3d.DAL.Entities
{
    public class User : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Phone { get; set; }

        [MaxLength(500)]
        public string? Address { get; set; }

        public UserRole Role { get; set; } = UserRole.Customer;

        public bool IsActive { get; set; } = true;

        // Shop-specific fields (ch? dùng khi Role = Shop)
        [MaxLength(200)]
        public string? ShopName { get; set; }

        [MaxLength(500)]
        public string? ShopDescription { get; set; }

        [MaxLength(500)]
        public string? LogoUrl { get; set; }

        [MaxLength(500)]
        public string? WebsiteUrl { get; set; }

        /// <summary>
        /// Mã s? thu? (cho Shop)
        /// </summary>
        [MaxLength(50)]
        public string? TaxCode { get; set; }

        /// <summary>
        /// Shop ?ã ???c xác minh
        /// </summary>
        public bool IsVerified { get; set; } = false;

        // Navigation properties
            public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
            public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
            public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
            public virtual ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
        }

    public enum UserRole
    {
        Customer = 0,
        Admin = 1,
        Staff = 2,
        Shop = 3
    }
}
