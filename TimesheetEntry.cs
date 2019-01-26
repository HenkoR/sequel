using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class TimesheetEntry
    {
        /*
           Name | Surname | Client | Project | Date | Time Started | Time ended | Duration | Description | Billable
           --- | --- | --- | --- | --- | --- | --- | --- | --- | ---
           John | Doe | Client X | Website | 2019-01-22 | 09:00 | 11:00 | 120 | I was rocking HTML5  | YES
           John | Doe | Client X | API | 2019-01-22 | 13:00 | 17:00 | 240 | Grafting on golang api  | YES
         */

        public int Id { get; set; }
      
        [ForeignKey("client")]
        public int clientID { get; set; }
        public string Project { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public bool Billable { get; set; }
    }
}
