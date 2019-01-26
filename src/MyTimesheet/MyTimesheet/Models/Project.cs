using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class Project
    {

        /*  Time Started | Time ended | Duration | Description             | Billable
            ------------ | ---------- | ---------| ----------------------- | ---
            09:00        | 11:00      | 120      | I was rocking HTML5     | YES
            13:00        | 17:00      | 240      | Grafting on golang api  | YES
        */

        public string ProjectId { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public bool Billable { get; set; }
    }
}
