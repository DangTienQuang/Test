using System;
using System.Collections.Generic;

namespace DataLabeling.Core.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Instruction { get; set; } = string.Empty;
        public string LabelConfig { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int ManagerId { get; set; }
        public User Manager { get; set; }

        public ICollection<DataItem> DataItems { get; set; }
    }
}