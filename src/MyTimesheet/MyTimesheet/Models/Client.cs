using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class Client
    {
        //Nedbank
        public int Id { get; set; }
        public string Name { get; set; }
        public Project project { get; set; }
    }
}
