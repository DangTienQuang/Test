using DataLabeling.Core.Enums;
using System;

namespace DataLabeling.Core.Entities
{
    public class LabelTask
    {
        public int Id { get; set; }

        public int DataItemId { get; set; }
        public DataItem DataItem { get; set; }

        public int? AnnotatorId { get; set; } 
        public User Annotator { get; set; }

        public ProjectTaskStatus Status { get; set; } = ProjectTaskStatus.New;
        public ErrorType? ErrorType { get; set; }
        public string? LabelData { get; set; }

        public string? ReviewerComment { get; set; }

        public DateTime? LastUpdated { get; set; }
    }
}