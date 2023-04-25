using System.ComponentModel.DataAnnotations;

namespace Lab4.WPF.Models
{
    public class DiagnosisForCreationDto
    {
        [Required(ErrorMessage = "Diagnosis title is required")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
