using AutoMapper;
using Business.Requests.Applicant;
using Business.Responses.Applicant;
using Entities.Concretes;

namespace Business.Profiles.Applicants;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Applicant, CreateApplicantRequest>().ReverseMap();
        CreateMap<Applicant, DeleteApplicantRequest>().ReverseMap();
        CreateMap<Applicant, UpdateApplicantRequest>().ReverseMap();

        CreateMap<Applicant, CreatedApplicantResponse>().ReverseMap();
        CreateMap<Applicant, DeletedApplicantResponse>().ReverseMap();
        CreateMap<Applicant, UpdatedApplicantResponse>().ReverseMap();
        CreateMap<Applicant, GetAllApplicantResponse>().ReverseMap();
        CreateMap<Applicant, GetByIdApplicantResponse>().ReverseMap();
    }
}
