using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLabeling.Core.DTOs
{

    public class CreateProjectDto
    {
        [Required(ErrorMessage = "Tên dự án không được để trống")]
        [MaxLength(100, ErrorMessage = "Tên dự án không quá 100 ký tự")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        public string Instruction { get; set; } = string.Empty;

        public string LabelConfig { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "ManagerId không hợp lệ")]
        public int ManagerId { get; set; }
    }

    public class AddDataItemDto
    {
        [Required]
        public int ProjectId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Cần ít nhất 1 ảnh để upload")]
        public List<string> ImageUrls { get; set; }
    }

    public class ProjectViewDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TotalImages { get; set; }
        public string ManagerName { get; set; } = string.Empty;
    }
}