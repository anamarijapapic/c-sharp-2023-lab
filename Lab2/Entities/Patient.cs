using Bogus;
using static Bogus.DataSets.Name;

namespace Lab2.Entities
{
    public class Patient
    {
        public string Oib { get; set; }
        public string Mbo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Diagnosis { get; set; }

        public Patient() { }

        public Patient(string oib,
            string mbo,
            string firstName,
            string lastName,
            DateTime dateOfBirth,
            Gender gender,
            string diagnosis)
        {
            Oib = oib;
            Mbo = mbo;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Diagnosis = diagnosis;
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
                .RuleFor(p => p.Diagnosis, f => f.Lorem.Sentence());

            return faker.Generate(seedPatientsCnt);
        }

        public override string ToString()
        {
            return $@"
OIB: {Oib}
MBO: {Mbo}
First name: {FirstName}
Last name: {LastName}
Date of birth: {DateOfBirth.ToString("d")}
Gender: {Gender}
Diagnosis: {Diagnosis}";
        }
    }
}
