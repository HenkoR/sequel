using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class ProjectDetails
    {
        public int Id { get; set; }
        public string Client { get; set; }
        public string Project { get; set; }
        public string Description { get; set; }
        public bool Billable { get; set; }
    }
}
