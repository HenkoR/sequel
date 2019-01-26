using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        /*
           | Name | Surname  | Dev_ID   | Description
           | ---  | ---------| -------- | ----------                       Developer
           | John | Doe      | 1        | I was rocking HTML5 
           | John | Doe      | 2        | Grafting on golang api 

           | Client_ID | Name      |
           | --------  | ------    |
           | John      | Client X  |                                       Client
           | John      | Client X  |


           | Project  | Billable    | Client_ID |
           | -------- | ----------- | --------  |
           | Client X | YES         | 001       |                          Project
           | Client X | YES         | 002       |


           | Client_ID   | Project_ID | Date       | Time Started | Time ended | Duration |
           | ---         | ---        | ---------  | ------------ | ---------- | -------- |                ProjectDate
           | 001         | Website    | 2019-01-22 | 09:00        | 11:00      | 120      |
           | 002         | API        | 2019-01-22 | 13:00        | 17:00      | 240      |

        Lindani R Mabaso
        */


        [Key]
        public int Timesheet_ID { get; set; }
        [ForeignKey("Cient")]
        public int Client_ID { get; set; }
        public bool Billable { get; set; }
        [ForeignKey("Project")]
        public int Project_ID { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Dev_ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Description { get; set; }

    }
}
 