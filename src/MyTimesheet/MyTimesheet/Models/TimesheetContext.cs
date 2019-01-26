using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyTimesheet.Models
{
    public class TimesheetContext : DbContext
    {
        public TimesheetContext(DbContextOptions<TimesheetContext> options)
            : base(options)
        { }

        public DbSet<TimesheetEntry> Entries { get; set; }
        public DbSet<Date> Date { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Client> Client { get; set; }
    }
}
