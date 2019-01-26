using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class EmployeeEntry
    {

        [Key]
        public int Employee_ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
