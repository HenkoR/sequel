using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class Developer
    {
        /*
                Id   |  Name  | Surname| 
                     |   -----| -------| 
               201   |   John | Doe    | 
               107   |   John | Doe    | 
        */

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
