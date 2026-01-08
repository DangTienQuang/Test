using System.ComponentModel.DataAnnotations;

namespace DataLabeling.Core.Entities
{
    public class SystemConfig
    {
        public int Id { get; set; }
        [Required]
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}