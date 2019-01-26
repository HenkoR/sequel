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
        public DbSet<Developer> DeveloperEntries { get; set; }
        public DbSet<ProjectDateTime> ProjectDateTimeEntries { get; set; }
        public DbSet<ProjectDetails> ProjectDetailsEntries { get; set; }

    }
}
