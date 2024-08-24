﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vitals.Repository.Data;

#nullable disable

namespace Vitals.Repository.Migrations.Data
{
    [DbContext(typeof(VitalsDbContext))]
    [Migration("20240820083329_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Vitals.Core.Entities.AllergiesReadings", b =>
                {
                    b.Property<string>("UId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NotedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reaction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Severity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Stat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SubType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UId");

                    b.HasIndex("EntryId");

                    b.ToTable("AllergiesReadings");
                });

            modelBuilder.Entity("Vitals.Core.Entities.Entry", b =>
                {
                    b.Property<string>("UId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PathOfFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SectionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UploadedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Userid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("source")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UId");

                    b.ToTable("Entry");
                });

            modelBuilder.Entity("Vitals.Core.Entities.HistoryReadings", b =>
                {
                    b.Property<string>("UId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Age")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NotedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UId");

                    b.HasIndex("EntryId");

                    b.ToTable("HistoryReadings");
                });

            modelBuilder.Entity("Vitals.Core.Entities.LabReadings", b =>
                {
                    b.Property<string>("UId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LabCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LabTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("NotedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Units")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UId");

                    b.HasIndex("EntryId");

                    b.ToTable("LabReadings");
                });

            modelBuilder.Entity("Vitals.Core.Entities.MedicalDocuments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EntryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FileType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ofn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("filePath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EntryId");

                    b.ToTable("MedicalDocuments");
                });

            modelBuilder.Entity("Vitals.Core.Entities.Medications_Readings", b =>
                {
                    b.Property<string>("UId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Directions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EndDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("MedCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quantity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UId");

                    b.HasIndex("EntryId");

                    b.ToTable("Medications_Readings");
                });

            modelBuilder.Entity("Vitals.Core.Entities.PatientVitals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("VitalDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VitalTypes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VitalValues")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PatientVitals");
                });

            modelBuilder.Entity("Vitals.Core.Entities.PrescriptsReadings", b =>
                {
                    b.Property<string>("UId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PresCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UId");

                    b.HasIndex("EntryId");

                    b.ToTable("PrescriptsReadings");
                });

            modelBuilder.Entity("Vitals.Core.Entities.ProblemsReadings", b =>
                {
                    b.Property<string>("UId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ICD10")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NotedDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UId");

                    b.HasIndex("EntryId");

                    b.ToTable("ProblemsReadings");
                });

            modelBuilder.Entity("Vitals.Core.Entities.VitalReadings", b =>
                {
                    b.Property<string>("UId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EntryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("NotedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TypeOfVital")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Units")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UId");

                    b.HasIndex("EntryId");

                    b.ToTable("VitalReadings");
                });

            modelBuilder.Entity("Vitals.Core.Entities.AllergiesReadings", b =>
                {
                    b.HasOne("Vitals.Core.Entities.Entry", "Entry")
                        .WithMany("AllergiesReadings")
                        .HasForeignKey("EntryId");

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("Vitals.Core.Entities.HistoryReadings", b =>
                {
                    b.HasOne("Vitals.Core.Entities.Entry", "Entry")
                        .WithMany("HistoryReadings")
                        .HasForeignKey("EntryId");

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("Vitals.Core.Entities.LabReadings", b =>
                {
                    b.HasOne("Vitals.Core.Entities.Entry", "Entry")
                        .WithMany("LabReadings")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("Vitals.Core.Entities.MedicalDocuments", b =>
                {
                    b.HasOne("Vitals.Core.Entities.Entry", "Entry")
                        .WithMany()
                        .HasForeignKey("EntryId");

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("Vitals.Core.Entities.Medications_Readings", b =>
                {
                    b.HasOne("Vitals.Core.Entities.Entry", "Entry")
                        .WithMany("Medications_Readings")
                        .HasForeignKey("EntryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("Vitals.Core.Entities.PrescriptsReadings", b =>
                {
                    b.HasOne("Vitals.Core.Entities.Entry", "Entry")
                        .WithMany("PrescriptsReadings")
                        .HasForeignKey("EntryId");

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("Vitals.Core.Entities.ProblemsReadings", b =>
                {
                    b.HasOne("Vitals.Core.Entities.Entry", "Entry")
                        .WithMany("ProblemsReadings")
                        .HasForeignKey("EntryId");

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("Vitals.Core.Entities.VitalReadings", b =>
                {
                    b.HasOne("Vitals.Core.Entities.Entry", "Entry")
                        .WithMany("VitalReadings")
                        .HasForeignKey("EntryId");

                    b.Navigation("Entry");
                });

            modelBuilder.Entity("Vitals.Core.Entities.Entry", b =>
                {
                    b.Navigation("AllergiesReadings");

                    b.Navigation("HistoryReadings");

                    b.Navigation("LabReadings");

                    b.Navigation("Medications_Readings");

                    b.Navigation("PrescriptsReadings");

                    b.Navigation("ProblemsReadings");

                    b.Navigation("VitalReadings");
                });
#pragma warning restore 612, 618
        }
    }
}
