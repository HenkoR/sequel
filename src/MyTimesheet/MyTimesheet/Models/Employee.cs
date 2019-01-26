using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string JobTitle { get; set; }
        public string Team { get; set; }

        public ICollection<Project> getProjects { set; get; }
    }
}
