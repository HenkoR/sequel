using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class TimesheetEntry
    {
        public int Id { get; set;
        public Employee Employee { get; set; }        
        public Project Project { get; set; }
        public string Client { get; set; }
        public DateTime Date { get; set; }
    }
}
