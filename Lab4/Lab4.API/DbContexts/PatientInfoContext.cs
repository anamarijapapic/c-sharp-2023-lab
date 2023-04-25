using Lab4.API.Entities;
using Microsoft.EntityFrameworkCore;
namespace Lab4.API.DbContexts
{
    public class PatientInfoContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Diagnosis> Diagnoses { get; set; } = null!;

        public PatientInfoContext(DbContextOptions<PatientInfoContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Diagnosis>()
             .HasData(
               new Diagnosis("A00-B99")
               {
                   Id = 1,
                   Description = "Određene infekcijske i parazitske bolesti"
               },
               new Diagnosis("C00-D48")
               {
                   Id = 2,
                   Description = "Neoplazme"
               },
               new Diagnosis("C50-D89")
               {
                   Id = 3,
                   Description = "Bolesti krvi i krvotvornih organa i određeni poremećaji imunološkog sustava"
               },
               new Diagnosis("E00-E90")
               {
                   Id = 4,
                   Description = "Endokrine, nutricijske i metaboličke bolesti"
               },
               new Diagnosis("F00-F99")
               {
                   Id = 5,
                   Description = "Mentalni poremećaji i poremećaji ponašanja"
               },
               new Diagnosis("G00-G99")
               {
                   Id = 6,
                   Description = "Bolesti živčanog sustava"
               },
               new Diagnosis("H00-H59")
               {
                   Id = 7,
                   Description = "Bolesti oka i adneksa"
               },
               new Diagnosis("H60-H95")
               {
                   Id = 8,
                   Description = "Bolesti uha i mastoidnih procesa"
               },
               new Diagnosis("I00-I99")
               {
                   Id = 9,
                   Description = "Bolesti cirkulacijskog (krvožilnog) sustava"
               },
               new Diagnosis("J00-J99")
               {
                   Id = 10,
                   Description = "Bolesti dišnog (respiracijskog) sustava"
               }
               );

            modelBuilder.Entity<Patient>()
                .HasData(
                new Patient()
                {
                    Id = 1,
                    FirstName = "Anamarija",
                    LastName = "Papić",
                    DateOfBirth = DateTime.Parse("9/1/2001"),
                    DateOfAdmittance = DateTime.Parse("1/4/2023"),
                    DateOfDischarge = DateTime.Parse("17/4/2023"),
                    DiagnosisId = 1,
                    PatientMbo = "111111111",
                    PatientOib = "11111111111",
                    PatientGender = Gender.Female,
                    PatientInsurance = Insurance.Supplementary,
                    IsDischarged = true
                },
                new Patient()
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Parse("1/1/2000"),
                    DateOfAdmittance = DateTime.Parse("16/4/2023"),
                    DateOfDischarge = DateTime.Parse("17/4/2023"),
                    DiagnosisId = 2,
                    PatientMbo = "222222222",
                    PatientOib = "22222222222",
                    PatientGender = Gender.Male,
                    PatientInsurance = Insurance.Basic,
                    IsDischarged = true
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
