using Lab5_6.Entities;
using Lab5_6.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab5_6.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IPatientService _patientService;

        public IndexModel(ILogger<IndexModel> logger, IPatientService patientService)
        {
            _logger = logger;
            _patientService = patientService;
        }

        public IEnumerable<Patient>? Patients { get; set; }

        public List<string> PropertyNames;

        public async Task OnGet(string sortOrder, string searchString)
        {
            ViewData["CurrentSort"] = sortOrder;

            Patients = await _patientService.GetAllAsync();

            PropertyNames = _patientService.getFieldNames();

            Patients = _patientService.sortingSelection(Patients, sortOrder);

            Patients = _patientService.searchSelection(Patients, searchString);
        }
    }
}
