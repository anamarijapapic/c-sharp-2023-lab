using System.ComponentModel.DataAnnotations;

namespace Lab4.API.Models
{
    public class DiagnosisForUpdateDto
    {
        [Required(ErrorMessage = "Diagnosis title is required")]
        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Description { get; set; }
    }
}
