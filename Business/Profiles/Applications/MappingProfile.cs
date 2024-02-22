using AutoMapper;
using Business.Requests.Applications;
using Business.Responses.Applications;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Applications;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Application, CreateApplicationRequest>().ReverseMap();
        CreateMap<Application, DeleteApplicationRequest>().ReverseMap();
        CreateMap<Application, UpdateApplicationRequest>().ReverseMap();

        CreateMap<Application, CreatedApplicationResponse>().ReverseMap();
        CreateMap<Application, DeletedApplicationResponse>().ReverseMap();
        CreateMap<Application, UpdatedApplicationResponse>().ReverseMap();
        CreateMap<Application, GetAllApplicationResponse>().ReverseMap();
        CreateMap<Application, GetByIdApplicationResponse>().ReverseMap();
    }
}
