using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class Project
    {
        public string ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public bool Billable { get; set; }
    }
}

