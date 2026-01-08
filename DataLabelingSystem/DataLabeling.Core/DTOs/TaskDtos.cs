using DataLabeling.Core.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLabeling.Core.DTOs
{
    public class AssignTaskDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "ID người gán nhãn không hợp lệ")]
        public int AnnotatorId { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Phải chọn ít nhất 1 nhiệm vụ")]
        public List<int> TaskIds { get; set; }
    }

    public class SubmitLabelDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "TaskId không hợp lệ")]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Dữ liệu nhãn không được để trống")]
        public string LabelData { get; set; } = string.Empty;
    }

    public class ReviewTaskDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "TaskId không hợp lệ")]
        public int TaskId { get; set; }

        [Required]
        public bool IsApproved { get; set; }

        [MaxLength(500, ErrorMessage = "Nhận xét không quá 500 ký tự")]
        public string? Comment { get; set; }

        public ErrorType? ErrorType { get; set; }
    }
    public class TaskViewDto
    {
        public int Id { get; set; }
        public string DataUrl { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public string Instruction { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string? LabelData { get; set; }
        public string? ReviewerComment { get; set; }
        public string ErrorType { get; set; } = string.Empty;
        public string LabelConfig { get; set; } = string.Empty;
    }

}