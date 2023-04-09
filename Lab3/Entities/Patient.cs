using Bogus;
using Lab3.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using static Bogus.DataSets.Name;

namespace Lab3.Entities
{
    public class Patient
    {
        public string Oib { get; set; }
        public string Mbo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public Diagnosis Diagnosis { get; set; }

        private List<List<DateTime?>> HospitalStays { get; set; }

        public Patient() { }

        public Patient(string oib,
            string mbo,
            string firstName,
            string lastName,
        DateTime dateOfBirth,
            Gender gender,
            Diagnosis diagnosis)
        {
            Oib = oib;
            Mbo = mbo;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Diagnosis = diagnosis;
            HospitalStays = new List<List<DateTime?>>();
        }

        public static List<Patient> SeedPatients(int seedPatientsCnt)
        {
            var faker = new Faker<Patient>()
                .RuleFor(p => p.Oib, f => string.Join("", f.Random.Digits(11)))
                .RuleFor(p => p.Mbo, f => string.Join("", f.Random.Digits(9)))
                .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                .RuleFor(p => p.LastName, f => f.Person.LastName)
                .RuleFor(p => p.DateOfBirth, f => f.Person.DateOfBirth)
                .RuleFor(p => p.Gender, f => f.Person.Gender)
                .RuleFor(p => p.Diagnosis, f => f.PickRandom<Diagnosis>())
                .RuleFor(p => p.HospitalStays, f => new List<List<DateTime?>>());

            return faker.Generate(seedPatientsCnt);
        }

        public void Admitt()
        {
            HospitalStays.Add(new List<DateTime?> { DateTime.Now, null });
        }

        public void Discharge()
        {
            var hospitalStay = HospitalStays.Find(hs => hs.ElementAt(1) == null);
            if (hospitalStay != null)
            {
                hospitalStay[1] = DateTime.Now;
            }
        }

        public bool isCurrentlyAdmitted()
        {
            return HospitalStays.Any(hs => hs.ElementAt(1) == null);
        }
    }
}
