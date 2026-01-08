namespace DataLabeling.Core.Entities
{
    public class DataItem
    {
        public int Id { get; set; }
        public string DataUrl { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public LabelTask LabelTask { get; set; }
    }
}