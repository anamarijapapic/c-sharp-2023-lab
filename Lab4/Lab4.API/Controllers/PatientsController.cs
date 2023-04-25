using AutoMapper;
using Lab4.API.Entities;
using Lab4.API.Models;
using Lab4.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lab4.API.Controllers
{
    [ApiController]
    [Route("api/patients")]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientInfoRepository _patientInfoRepository;

        private readonly IMapper _mapper;

        public PatientsController(IPatientInfoRepository patientInfoRepository, IMapper mapper)
        {
            _patientInfoRepository = patientInfoRepository ?? throw new ArgumentNullException(nameof(patientInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientDto>>> GetPatients()
        {
            var patients = await _patientInfoRepository.GetPatientsAsync();
            var results = new List<PatientDto>();

            foreach (var patient in patients)
            {
                var diagnosis = await _patientInfoRepository.GetDiagnosisAsync(patient.DiagnosisId);
                results.Add(_mapper.Map<PatientDto>(patient));
            }

            return Ok(results);
        }

        [HttpGet("{patientId}", Name = "GetPatients")]
        public async Task<ActionResult<PatientDto>> GetPatient(int patientId)
        {
            var patient = await _patientInfoRepository.GetPatientAsync(patientId);

            if (patient is null)
            {
                return NotFound();
            }

            var diagnosis = await _patientInfoRepository.GetDiagnosisAsync(patient.DiagnosisId);
            var patientForReturn = _mapper.Map<PatientDto>(patient);

            return Ok(patientForReturn);
        }

        [HttpPost]
        public async Task<ActionResult<PatientDto>> CreatePatient(PatientForCreateDto patient)
        {
            var diagnosis = await _patientInfoRepository.GetDiagnosisAsync(patient.DiagnosisId);
            var finalPatient = _mapper.Map<Patient>(patient);
            await _patientInfoRepository.AddPatientAsync(finalPatient);
            await _patientInfoRepository.SaveChangesAsync();

            return Ok(_mapper.Map<PatientDto>(finalPatient));
        }

        [HttpPut("{patientId}")]
        public async Task<ActionResult> UpdatePatient(int patientId, PatientForCreateDto patient)
        {
            if (!await _patientInfoRepository.PatientExistsAsync(patientId))
            {
                return NotFound();
            }

            var patientFromDatabase = await _patientInfoRepository.GetPatientAsync(patientId);

            if (patientFromDatabase == null)
            {
                return NotFound();
            }

            var diagnosis = await _patientInfoRepository.GetDiagnosisAsync(patient.DiagnosisId);
            var updatedPatient = _mapper.Map<Patient>(patient);

            if (await _patientInfoRepository.GetDiagnosisAsync(updatedPatient.DiagnosisId) == null)
            {
                return BadRequest();
            }

            patientFromDatabase.FirstName = updatedPatient.FirstName;
            patientFromDatabase.LastName = updatedPatient.LastName;
            patientFromDatabase.PatientGender = updatedPatient.PatientGender;
            patientFromDatabase.PatientOib = updatedPatient.PatientOib;
            patientFromDatabase.PatientMbo = updatedPatient.PatientMbo;
            patientFromDatabase.DateOfBirth = updatedPatient.DateOfBirth;
            patientFromDatabase.DateOfAdmittance = updatedPatient.DateOfAdmittance;
            patientFromDatabase.DateOfDischarge = updatedPatient.DateOfDischarge;
            patientFromDatabase.DiagnosisId = updatedPatient.DiagnosisId;
            patientFromDatabase.IsDischarged = updatedPatient.IsDischarged;
            patientFromDatabase.PatientInsurance = updatedPatient.PatientInsurance;

            await _patientInfoRepository.SaveChangesAsync();

            return Ok(_mapper.Map<PatientDto>(patientFromDatabase));
        }

        [HttpDelete("{patientId}")]
        public async Task<ActionResult> DeletePatient(int patientId)
        {
            if (!await _patientInfoRepository.PatientExistsAsync(patientId))
            {
                return NotFound();
            }

            var patient = await _patientInfoRepository.GetPatientAsync(patientId);

            if (patient == null)
            {
                return NotFound();
            }

            _patientInfoRepository.DeletePatient(patient);
            await _patientInfoRepository.SaveChangesAsync();

            return Ok($"You successfully deleted patient: {patient.FirstName} {patient.LastName} with MBO: {patient.PatientMbo}");
        }
    }
}
