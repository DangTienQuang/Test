using System;
using System.ComponentModel.DataAnnotations;

namespace FIt3d.DAL.Entities
{
    /// <summary>
    /// Model 3D (dùng cho c? User B2C và Shop B2B)
    /// </summary>
    public class Model : BaseEntity
    {
        public Guid SubscriptionId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Description { get; set; }

        /// <summary>
        /// URL l?u tr? model 3D
        /// </summary>
        [MaxLength(1000)]
        public string? ModelFileUrl { get; set; }

        /// <summary>
        /// URL thumbnail
        /// </summary>
        [MaxLength(1000)]
        public string? ThumbnailUrl { get; set; }

        /// <summary>
        /// D? li?u c?u hình model (JSON) - màu s?c, size, outfit combinations, etc.
        /// </summary>
        public string? ConfigurationData { get; set; }

        /// <summary>
        /// D? li?u s?n ph?m liên k?t (JSON) - danh sách ProductId
        /// </summary>
        public string? LinkedProductsData { get; set; }

        /// <summary>
        /// Dung l??ng file (bytes)
        /// </summary>
        public long FileSizeBytes { get; set; }

        /// <summary>
        /// S? l?n ?ã ch?nh s?a
        /// </summary>
        public int EditCount { get; set; }

        /// <summary>
        /// S? l?n ch?nh s?a t?i ?a cho phép
        /// </summary>
        public int MaxEditCount { get; set; } = 10;

        /// <summary>
        /// Cho phép hi?n th? công khai (dành cho shop)
        /// </summary>
        public bool IsPublic { get; set; } = false;

        public bool IsActive { get; set; } = true;

        // Navigation properties
        public virtual Subscription Subscription { get; set; } = null!;
    }
}
