using AutoMapper;
using Business.Requests.User;
using Business.Responses.User;
using Core.Utilities.Security.Entities;

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
