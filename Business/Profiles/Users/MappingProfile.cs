using AutoMapper;
using Business.Requests.Applications;
using Business.Requests.User;
using Business.Responses.Applications;
using Business.Responses.User;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles.Users;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<User, CreateUserRequest>().ReverseMap();
        CreateMap<User, DeleteUserRequest>().ReverseMap();
        CreateMap<User, UpdateUserRequest>().ReverseMap();

        CreateMap<User, CreatedUserResponse>().ReverseMap();
        CreateMap<User, DeletedUserResponse>().ReverseMap();
        CreateMap<User, UpdatedUserResponse>().ReverseMap();
        CreateMap<User, GetAllUserResponse>().ReverseMap();
        CreateMap<User, GetByIdUserResponse>().ReverseMap();
    }
}
