using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Lab4.API.Entities
{
    public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        public string? PatientOib { get; set; }

        [Required]
        [StringLength(9)]
        public string? PatientMbo { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [ForeignKey("DiagnosisId")]
        public Diagnosis? Diagnosis { get; set; }
        public int DiagnosisId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfAdmittance { get; set; }
        public DateTime DateOfDischarge { get; set; }
        public Gender PatientGender { get; set; }
        public Insurance PatientInsurance { get; set; }
        public bool IsDischarged { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }

    public enum Insurance
    {
        Basic,
        Supplementary,
        Uninsured
    }
}
