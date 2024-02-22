using AutoMapper;
using Business.Requests.Bootcamps;
using Business.Requests.BootcampStates;
using Business.Responses.Bootcamps;
using Business.Responses.BootcampStates;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.BootcampStates;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<BootcampState, CreateBootcampStateRequest>().ReverseMap();
        CreateMap<BootcampState, DeleteBootcampStateRequest>().ReverseMap();
        CreateMap<BootcampState, UpdateBootcampStateRequest>().ReverseMap();

        CreateMap<BootcampState, CreatedBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, DeletedBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, UpdatedBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, GetAllBootcampStateResponse>().ReverseMap();
        CreateMap<BootcampState, GetByIdBootcampStateResponse>().ReverseMap();
    }
}
