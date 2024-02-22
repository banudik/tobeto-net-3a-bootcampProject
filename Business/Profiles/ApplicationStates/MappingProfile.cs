using AutoMapper;
using Business.Requests.Applications;
using Business.Requests.ApplicationStates;
using Business.Responses.Applications;
using Business.Responses.ApplicationStates;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.ApplicationStates;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<ApplicationState, CreateApplicationStateRequest>().ReverseMap();
        CreateMap<ApplicationState, DeleteApplicationStateRequest>().ReverseMap();
        CreateMap<ApplicationState, UpdateApplicationStateRequest>().ReverseMap();

        CreateMap<ApplicationState, CreatedApplicationStateResponse>().ReverseMap();
        CreateMap<ApplicationState, DeletedApplicationStateResponse>().ReverseMap();
        CreateMap<ApplicationState, UpdatedApplicationStateResponse>().ReverseMap();
        CreateMap<ApplicationState, GetAllApplicationStateResponse>().ReverseMap();
        CreateMap<ApplicationState, GetByIdApplicationStateResponse>().ReverseMap();
    }
}
