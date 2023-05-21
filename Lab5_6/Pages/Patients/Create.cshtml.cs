using Lab5_6.Entities;
using Lab5_6.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab5_6.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly IPatientService _patientService;

        public CreateModel(ILogger<CreateModel> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        [BindProperty]
        public Patient patient { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                System.Diagnostics.Debug.WriteLine(errors);
                return Page();
            }

            await _patientService.AddAsync(patient);

            return Page();
        }
    }
}
