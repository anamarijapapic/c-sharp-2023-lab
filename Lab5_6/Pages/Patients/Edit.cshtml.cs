using Lab5_6.Entities;
using Lab5_6.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab5_6.Pages.Patients
{
    public class EditModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPatientService _patientService;

        public EditModel(ILogger<IndexModel> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        [BindProperty]
        public Patient? Patient { get; set; }

        [BindProperty]
        public Discharge Discharge { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
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

            if (Patient.DischargeDate.HasValue)
            {
                Discharge = new Discharge();
                Discharge.Date = Patient.DischargeDate.Value;
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Patient != null)
            {
                if (Discharge != null)
                {
                    Patient!.DischargeDate = Discharge!.Date;
                }
                await _patientService.UpdateAsync(Patient);
            }

            return RedirectToPage("/Patients/Index");
        }
    }
}
