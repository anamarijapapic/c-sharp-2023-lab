using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4.WPF.Entities
{
    public class Diagnosis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string? Description { get; set; }

        public ICollection<Patient> Patients { get; set; } = new List<Patient>();

        public Diagnosis(string title)
        {
            Title = title;
        }
    }
}
