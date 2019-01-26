using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class Client
    {
        /*
           Id        | Client   | Project | Date        | Duration | Description             | Billable
                 ----|          | ---     | ---         | ---      |                         | ---    
         1002        | Client X | Website | 2019-01-22  | 120      | I was rocking HTML5     | YES
         1805        | Client X | API     | 2019-01-22  | 240      | Grafting on golang api  | YES
        */

        public int Id { get; set; }
        public string Clients { get; set; }
        public string Project { get; set; }
        public DateTime Date { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public bool Billable { get; set; }
    }
}
