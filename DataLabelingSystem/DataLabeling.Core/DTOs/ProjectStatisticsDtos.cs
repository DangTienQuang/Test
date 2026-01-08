using System.Collections.Generic;

namespace DataLabeling.Core.DTOs
{
    public class ProjectProgressDto
    {
        public int ProjectId { get; set; }
        public int TotalItems { get; set; }      
        public int NewItems { get; set; }      
        public int InProgressItems { get; set; } 
        public int SubmittedItems { get; set; } 
        public int RejectedItems { get; set; }  
        public int ApprovedItems { get; set; }   
        public double PercentComplete { get; set; } 
    }

    public class ExportDataItemDto
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string Url { get; set; }
        public string LabelData { get; set; }    
        public string AnnotatorName { get; set; }
        public string ReviewerComment { get; set; }
    }
}