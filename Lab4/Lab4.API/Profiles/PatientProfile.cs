using AutoMapper;

namespace Lab4.API.Profiles
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Entities.Patient, Models.PatientDto>();
            CreateMap<Models.PatientForCreateDto, Entities.Patient>();
        }
    }
}
