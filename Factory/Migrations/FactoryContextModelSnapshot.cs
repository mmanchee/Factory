﻿// <auto-generated />
using Factory.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Factory.Migrations
{
    [DbContext(typeof(FactoryContext))]
    partial class FactoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Factory.Models.Engineer", b =>
                {
                    b.Property<int>("EngineerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Contact");

                    b.Property<string>("HireDate");

                    b.Property<string>("Name");

                    b.HasKey("EngineerId");

                    b.ToTable("Engineers");
                });

            modelBuilder.Entity("Factory.Models.EngineerLicense", b =>
                {
                    b.Property<int>("EngineerLicenseId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("EngineerId");

                    b.Property<int>("LicenseId");

                    b.HasKey("EngineerLicenseId");

                    b.HasIndex("EngineerId");

                    b.HasIndex("LicenseId");

                    b.ToTable("EngineerLicense");
                });

            modelBuilder.Entity("Factory.Models.License", b =>
                {
                    b.Property<int>("LicenseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("LicenseId");

                    b.ToTable("Licenses");
                });

            modelBuilder.Entity("Factory.Models.LicenseType", b =>
                {
                    b.Property<int>("LicenseTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LicenseId");

                    b.Property<int>("MachineTypeId");

                    b.HasKey("LicenseTypeId");

                    b.HasIndex("LicenseId");

                    b.HasIndex("MachineTypeId");

                    b.ToTable("LicenseType");
                });

            modelBuilder.Entity("Factory.Models.Machine", b =>
                {
                    b.Property<int>("MachineId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MachineTypeId");

                    b.Property<string>("Name");

                    b.Property<string>("Purchase");

                    b.Property<string>("SerialNumber");

                    b.HasKey("MachineId");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("Factory.Models.MachineType", b =>
                {
                    b.Property<int>("MachineTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("MachineTypeId");

                    b.ToTable("MachineTypes");
                });

            modelBuilder.Entity("Factory.Models.Record", b =>
                {
                    b.Property<int>("RecordId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Details");

                    b.Property<int>("EngineerId");

                    b.Property<string>("FinishDate");

                    b.Property<string>("Issue");

                    b.Property<string>("IssueDate");

                    b.Property<int>("MachineId");

                    b.Property<string>("RecordType");

                    b.HasKey("RecordId");

                    b.ToTable("Records");
                });

            modelBuilder.Entity("Factory.Models.EngineerLicense", b =>
                {
                    b.HasOne("Factory.Models.Engineer", "Engineer")
                        .WithMany("Licenses")
                        .HasForeignKey("EngineerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Factory.Models.License", "License")
                        .WithMany("Engineers")
                        .HasForeignKey("LicenseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Factory.Models.LicenseType", b =>
                {
                    b.HasOne("Factory.Models.License", "License")
                        .WithMany("MachineTypes")
                        .HasForeignKey("LicenseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Factory.Models.MachineType", "MachineType")
                        .WithMany("Licenses")
                        .HasForeignKey("MachineTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
