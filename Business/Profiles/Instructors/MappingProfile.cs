using AutoMapper;
using Business.Requests.Instructor;
using Business.Responses.Instructor;
using Entities.Concretes;

namespace Business.Profiles.Instructors;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Instructor, CreateInstructorRequest>().ReverseMap();
        CreateMap<Instructor, DeleteInstructorRequest>().ReverseMap();
        CreateMap<Instructor, UpdateInstructorRequest>().ReverseMap();

        CreateMap<Instructor, CreatedInstructorResponse>().ReverseMap();
        CreateMap<Instructor, DeletedInstructorResponse>().ReverseMap();
        CreateMap<Instructor, UpdatedInstructorResponse>().ReverseMap();
        CreateMap<Instructor, GetAllInstructorResponse>().ReverseMap();
        CreateMap<Instructor, GetByIdInstructorResponse>().ReverseMap();
    }
}
