using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class Project
    {
        [Key]
        public int Project_ID { get; set; }

        [ForeignKey("Cient")]
        public int Client_ID { get; set; }

        public bool Billable { get; set; }
    }
}
