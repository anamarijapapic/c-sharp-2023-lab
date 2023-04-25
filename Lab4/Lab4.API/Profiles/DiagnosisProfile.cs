using AutoMapper;

namespace Lab4.API.Profiles
{
    public class DiagnosisProfile : Profile
    {
        public DiagnosisProfile()
        {
            CreateMap<Entities.Diagnosis, Models.DiagnosisDto>();
        }
    }
}
