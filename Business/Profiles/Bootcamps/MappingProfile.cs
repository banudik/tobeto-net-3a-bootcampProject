using AutoMapper;
using Business.Requests.Applications;
using Business.Requests.Bootcamps;
using Business.Responses.Applications;
using Business.Responses.Bootcamps;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Bootcamps;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Bootcamp, CreateBootcampRequest>().ReverseMap();
        CreateMap<Bootcamp, DeleteBootcampRequest>().ReverseMap();
        CreateMap<Bootcamp, UpdateBootcampRequest>().ReverseMap();

        CreateMap<Bootcamp, CreatedBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, DeletedBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, UpdatedBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, GetAllBootcampResponse>().ReverseMap();
        CreateMap<Bootcamp, GetByIdBootcampResponse>().ReverseMap();
    }
}
