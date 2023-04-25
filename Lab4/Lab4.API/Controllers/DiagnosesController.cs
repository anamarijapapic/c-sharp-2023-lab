using AutoMapper;
using Lab4.API.Models;
using Lab4.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.API.Controllers
{
    [Route("api/diagnoses")]
    [ApiController]
    public class DiagnosisController : ControllerBase
    {
        private readonly ILogger<DiagnosisController> _logger;

        private readonly IPatientInfoRepository _patientInfoRepository;

        private readonly IMapper _mapper;

        public DiagnosisController(ILogger<DiagnosisController> logger, IPatientInfoRepository patientInfoRepository, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _patientInfoRepository = patientInfoRepository ?? throw new ArgumentNullException(nameof(patientInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiagnosisDto>>> GetDiagnosisList()
        {
            var diagnosesList = await _patientInfoRepository.GetDiagnosesListAsync();

            return Ok(_mapper.Map<IEnumerable<DiagnosisDto>>(diagnosesList));
        }

        [HttpGet("{diagnosisId}")]
        public async Task<ActionResult<DiagnosisDto?>> GetDiagnosis(int diagnosisId)
        {
            var diagnosis = await _patientInfoRepository.GetDiagnosisAsync(diagnosisId);

            if (diagnosis is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DiagnosisDto>(diagnosis));
        }
    }
}
