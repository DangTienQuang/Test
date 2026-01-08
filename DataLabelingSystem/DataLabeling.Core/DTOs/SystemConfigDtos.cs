using System.ComponentModel.DataAnnotations;

namespace DataLabeling.Core.DTOs
{
    public class SystemConfigDto
    {
        public int Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class UpdateSystemConfigDto
    {
        [Required]
        public string Key { get; set; } = string.Empty;
        [Required]
        public string Value { get; set; } = string.Empty;
    }
}