﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyTimesheet.Models;

namespace MyTimesheet.Migrations
{
    [DbContext(typeof(TimesheetContext))]
    partial class TimesheetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyTimesheet.Models.TimesheetEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Billable");

                    b.Property<int>("Client_ID");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("Duration");

                    b.Property<int>("Employee_ID");

                    b.Property<string>("Project");

                    b.Property<DateTime>("TimeEnd");

                    b.Property<DateTime>("TimeStart");

                    b.HasKey("Id");

                    b.ToTable("Entries");
                });
#pragma warning restore 612, 618
        }
    }
}
