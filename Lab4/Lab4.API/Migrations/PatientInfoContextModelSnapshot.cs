﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Lab4.API.DbContexts;

#nullable disable

namespace Lab4.API.Migrations
{
    [DbContext(typeof(PatientInfoContext))]
    partial class PatientInfoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("Lab4.API.Entities.Diagnosis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Diagnoses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Određene infekcijske i parazitske bolesti",
                            Title = "A00-B99"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Neoplazme",
                            Title = "C00-D48"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Bolesti krvi i krvotvornih organa i određeni poremećaji imunološkog sustava",
                            Title = "C50-D89"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Endokrine, nutricijske i metaboličke bolesti",
                            Title = "E00-E90"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Mentalni poremećaji i poremećaji ponašanja",
                            Title = "F00-F99"
                        },
                        new
                        {
                            Id = 6,
                            Description = "Bolesti živčanog sustava",
                            Title = "G00-G99"
                        },
                        new
                        {
                            Id = 7,
                            Description = "Bolesti oka i adneksa",
                            Title = "H00-H59"
                        },
                        new
                        {
                            Id = 8,
                            Description = "Bolesti uha i mastoidnih procesa",
                            Title = "H60-H95"
                        },
                        new
                        {
                            Id = 9,
                            Description = "Bolesti cirkulacijskog (krvožilnog) sustava",
                            Title = "I00-I99"
                        },
                        new
                        {
                            Id = 10,
                            Description = "Bolesti dišnog (respiracijskog) sustava",
                            Title = "J00-J99"
                        });
                });

            modelBuilder.Entity("Lab4.API.Entities.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfDischarge")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfAdmittance")
                        .HasColumnType("TEXT");

                    b.Property<int>("DiagnosisId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsDischarged")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<int>("PatientGender")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PatientInsurance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PatientMbo")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("TEXT");

                    b.Property<string>("PatientOib")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("DiagnosisId");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfBirth = new DateTime(2001, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfAdmittance = new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfDischarge = new DateTime(2023, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDischarged = true,
                            DiagnosisId = 1,
                            FirstName = "Anamarija",
                            LastName = "Papić",
                            PatientGender = 1,
                            PatientInsurance = 1,
                            PatientMbo = "111111111",
                            PatientOib = "111111111111"
                        },
                        new
                        {
                            Id = 2,
                            DateOfBirth = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfAdmittance = new DateTime(2023, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfDischarge = new DateTime(2023, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsDischarged = true,
                            DiagnosisId = 2,
                            FirstName = "John",
                            LastName = "Doe",
                            PatientGender = 0,
                            PatientInsurance = 0,
                            PatientMbo = "222222222",
                            PatientOib = "22222222222"
                        });
                });

            modelBuilder.Entity("Lab4.API.Entities.Patient", b =>
                {
                    b.HasOne("Lab4.API.Entities.Diagnosis", "Diagnoses")
                        .WithMany("Patients")
                        .HasForeignKey("DiagnosisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diagnoses");
                });

            modelBuilder.Entity("Lab4.API.Entities.Diagnosis", b =>
                {
                    b.Navigation("Patients");
                });
#pragma warning restore 612, 618
        }
    }
}