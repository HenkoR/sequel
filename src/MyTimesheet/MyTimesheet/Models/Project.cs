using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models

{
    public class Project
    {
        [Key]
        public int Project_Id { get; set; }
        public int Client_ID { get; set; }
        public bool Billable { get; set; }


    }
}
