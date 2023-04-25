using AutoMapper;
namespace Lab4.WPF.Profiles
{
    public class DiagnosisProfile : Profile
    {
        public DiagnosisProfile()
        {
            CreateMap<Entities.Diagnosis, Models.DiagnosisDto>();
        }
    }
}
