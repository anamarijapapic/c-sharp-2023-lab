using Lab4.API.Entities;
namespace Lab4.API.Models
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string? PatientOib { get; set; }
        public string? PatientMbo { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DiagnosisDto? Diagnosis { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAdmittance { get; set; }
        public DateTime DateOfDischarge { get; set; }
        public Gender PatientGender { get; set; }
        public Insurance PatientInsurance { get; set; }
        public bool IsDischarged { get; set; }
    }
}
