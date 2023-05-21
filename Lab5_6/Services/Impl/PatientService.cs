using AutoMapper;
using Lab5_6.Entities;
using Lab5_6.Repository;

namespace Lab5_6.Services.Impl
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository<Patient> _patientRepository;
        public PatientService(IPatientRepository<Patient> patientRepository, IMapper mapper)
        {
            _patientRepository = patientRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _patientRepository.GetAllAsync();
        }

        public async Task<Patient> GetByIdAsync(Guid? id)
        {
            return await _patientRepository.GetByIdAsync(id);
        }

        public async Task<Patient> AddAsync(Patient patient)
        {
            return await _patientRepository.AddAsync(patient);
        }

        public async Task UpdateAsync(Patient patient)
        {
            await _patientRepository.UpdateAsync(patient);
        }
        public async Task DeleteAsync(Guid Id)
        {
            await _patientRepository.DeleteAsync(Id);
        }

        public IEnumerable<Patient> sortingSelection(IEnumerable<Patient> Patients, string sortOrder)
        {
            switch (sortOrder)
            {
                case "FirstName":
                    return Patients.OrderBy(s => s.FirstName);
                case "FirstNameDesc":
                    return Patients = Patients.OrderByDescending(s => s.FirstName);
                case "LastName":
                    return Patients.OrderBy(s => s.LastName);
                case "LastNameDesc":
                    return Patients.OrderByDescending(s => s.LastName);
                case "OIB":
                    return Patients.OrderBy(s => s.OIB);
                case "OIBDesc":
                    return Patients.OrderByDescending(s => s.OIB);
                case "MBO":
                    return Patients.OrderBy(s => s.MBO);
                case "MBODesc":
                    return Patients.OrderByDescending(s => s.MBO);
                case "AdmissionDate":
                    return Patients.OrderBy(s => s.AdmissionDate);
                case "AdmissionDateDesc":
                    return Patients.OrderByDescending(s => s.AdmissionDate);
                case "DischargeDate":
                    return Patients.OrderBy(s => s.DischargeDate);
                case "DischargeDateDesc":
                    return Patients.OrderByDescending(s => s.DischargeDate);
                default:
                    return Patients.OrderBy(s => s.LastName);
            }
        }

        public IEnumerable<Patient> searchSelection(IEnumerable<Patient> Patients, string searchString)
        {
            IEnumerable<Patient> PatientsSearched = Patients.ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                var searchStrTrim = searchString.Trim();
                PatientsSearched = Patients.Where(s => s.LastName.Contains(searchStrTrim)
                                            || s.FirstName.Contains(searchStrTrim)
                                            || s.OIB.Contains(searchStrTrim)
                                            || s.MBO.Contains(searchStrTrim)
                                            || s.AdmissionDate.ToString("dd/MM/yyyy").Contains(searchStrTrim)
                                            || (s.DischargeDate.HasValue && s.DischargeDate.Value.ToString("dd/MM/yyyy").Contains(searchStrTrim))
                                            );
            }
            return PatientsSearched;
        }


        public List<string> getFieldNames()
        {
            Patient Patient = new Patient();
            return Patient.GetType().GetProperties().Where(x => x.Name != "Id").Select(x => x.Name).ToList();
        }
    }
}
