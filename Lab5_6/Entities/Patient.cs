using Lab5_6.Entities.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab5_6.Entities;
public class Patient
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required]
    [StringLength(11, ErrorMessage = "The {0} must be {1} characters long.", MinimumLength = 11)]
    [RegularExpression(@"^\d+$", ErrorMessage = "Only digits are allowed.")]
    public string OIB { get; set; } = string.Empty;

    [Required]
    [StringLength(9, ErrorMessage = "The {0} must be {1} characters long.", MinimumLength = 9)]
    [RegularExpression(@"^\d+$", ErrorMessage = "Only digits are allowed.")]
    public string MBO { get; set; } = string.Empty;

    [Required]
    [StringLength(50, ErrorMessage = "The {0} exceeded maximum input value {1}")]
    [RegularExpression(@"^[a-zđčćšžA-ZĐČĆŠŽ\s]+$", ErrorMessage = "Only text is allowed")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50, ErrorMessage = "The {0} exceeded maximum input value {1}")]
    [RegularExpression(@"^[a-zđčćšžA-ZĐČĆŠŽ\s]+$", ErrorMessage = "Only text is allowed")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [Display(Name = "Date Of Birth")]
    public DateTime DateOfBirth { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [Required]
    public Diagnosis Diagnosis { get; set; }

    [Required]
    public Insurance Insurance { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Admission Date")]
    public DateTime AdmissionDate { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Discharge Date")]
    public DateTime? DischargeDate { get; set; } = null;
}
