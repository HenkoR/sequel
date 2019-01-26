using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class project
    {
        [Key]
        public int Id { get; set; }
        public Client client { get; set; }
        
        public string Project { get; set; }
       
    }
}
