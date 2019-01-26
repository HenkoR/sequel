using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class ProjectDate
    {
        [ForeignKey("Project")]
        public int Project_ID { get; set; }

        [ForeignKey("Client")]
        public int Client_ID { get; set; }

        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
    }
}
