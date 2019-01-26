using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
	public class ProjectDate
    {
        [ForeignKey("Project")]
        public int Project_Id { get; set; }

        [ForeignKey("Developer")]
        public int Developer_Id { get; set; }
        
        [Key]
        public int ProjectDate_Id { get; set; }

        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

    }
}
