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
        public int Id { get; set; }
        public int Name { get; set; }
        public Client Client { get; set; }
    }


}
