﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyTimesheet.Models;

namespace MyTimesheet.Migrations
{
    [DbContext(typeof(TimesheetContext))]
    [Migration("20190126171552_Normalized")]
    partial class Normalized
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyTimesheet.Models.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Client");

                    b.Property<string>("Name");

                    b.Property<string>("Surname");

                    b.Property<string>("projectId");

                    b.HasKey("Id");

                    b.HasIndex("projectId");

                    b.ToTable("Developer");
                });

            modelBuilder.Entity("MyTimesheet.Models.Project", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Billable");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<int>("Duration");

                    b.Property<string>("Project_1");

                    b.Property<DateTime>("TimeEnd");

                    b.Property<DateTime>("TimeStart");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("MyTimesheet.Models.Developer", b =>
                {
                    b.HasOne("MyTimesheet.Models.Project", "project")
                        .WithMany()
                        .HasForeignKey("projectId");
                });
#pragma warning restore 612, 618
        }
    }
}
