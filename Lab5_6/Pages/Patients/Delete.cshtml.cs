using Lab5_6.Entities;
using Lab5_6.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Lab5_6.Pages.Patients
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPatientService _patientService;

        public DeleteModel(ILogger<IndexModel> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        [BindProperty]
        public Patient? Patient { get; set; }

        public string ErrorMessage { get; set; }

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
            if (id == null)
            {
                return NotFound();
            }

            try
            {
                await _patientService.DeleteAsync(id ?? Guid.Empty);
                return RedirectToPage("/Patients");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);
                System.Diagnostics.Debug.WriteLine(ex);

                return RedirectToAction("./Error", new { id, saveChangesError = true });
            }
        }
    }
}
