using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        [Required]
        public string client { get; set; }
        [MaxLength(30)]
        [Required]
        public string Project { get; set; }
    }
}
