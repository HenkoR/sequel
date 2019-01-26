using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    /*
    public class TimesheetEntry
    {
        
        Name | Surname | Client   | Project | Date       | Time Started | Time ended | Duration | Description             | Billable
        --- | ---     | ---      | ---     |  ---       | --           |        --- |      --- |         ---             | ---
        John | Doe     | Client X | Website | 2019-01-22 | 09:00        | 11:00      | 120      |I was rocking HTML5      | YES
        John | Doe     | Client X | API     | 2019-01-22 | 13:00        | 17:00      | 240      | Grafting on golang api  | YES
         

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Client { get; set; }
        public string Project { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public bool Billable { get; set; }
    }
    
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }

    */

    public class TimesheetEntry
    {
        [Key]
        public int Id { get; set; }
        public Employee Employee { get; set; }// public int EmpId { get; set;}
        public Project Project { get; set; }//public int CId { get; set; }
        //public string Project { get; set; }
        public DateTime Date { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int Duration { get; set; }
        public string Description { get; set; }
        public bool Billable { get; set; }
        public override string ToString()
        {
            string val = "";
            val =   $"{{" +
                    $"\"id\": {Id},\n" +
                    $"\"employee\":{{\n" +
                        $"\"id\": {Employee.Id},\n" +
                        $"\"name\": \"{Employee.Name}\",\n" +
                        $"\"surname\":\"{Employee.Surname}\"\n" +
                    $"}},\n" +
                    $"\"project\":{{\n" +
                        $"\"id\": {Project.Id},\n" +
                        $"\"name\": \"{Project.Name}\",\n" +
                        $"\"client\": {{\n" +
                            $"\"id\": {Project.Client.Id},\n" +
                            $"\"name\": \"{Project.Client.Name}\"\n" +
                        $"}}\n" +
                    $"}},\n" +
                    $"\"date\": \"{Date.ToString()}\"\n" +
                    $"\"timeStart\": \"{TimeStart.ToString()}\",\n" +
                    $"\"timeEnd\": \"{TimeEnd.ToString()}\",\n" +
                    $"\"duration\": {Duration},\n" +
                    $"\"description\": \"{Description}\",\n" +
                    $"\"billable\": {Billable}\n" +
                $"}}";

            
            return val;
        }
    }
  

}
