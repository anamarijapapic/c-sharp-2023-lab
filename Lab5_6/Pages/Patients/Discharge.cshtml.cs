using Lab5_6.Entities;
using Lab5_6.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Lab5_6.Pages.Patients
{
    public class Discharge
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Discharge Date")]
        public DateTime Date { get; set; }
    }

    public class DischargeModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPatientService _patientService;

        public DischargeModel(ILogger<IndexModel> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        public string ErrorMessage { get; set; }

        public Patient? Patient { get; set; }

        [BindProperty]
        public Discharge? Discharge { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Patient = await _patientService.GetByIdAsync(id);


            if (Patient == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = string.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null) return NotFound();


            Patient = await _patientService.GetByIdAsync(id);

            if (Patient == null) return NotFound();

            Patient!.DischargeDate = Discharge!.Date;

            await _patientService.UpdateAsync(Patient);

            return RedirectToPage("/Patients");
        }
    }
}
