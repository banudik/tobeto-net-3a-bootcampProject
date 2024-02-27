using AutoMapper;
using Business.Requests.Blacklists;
using Business.Responses.Blacklists;
using Entities.Concretes;

namespace Business.Profiles.Blacklists;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Blacklist, CreateBlacklistRequest>().ReverseMap();
        CreateMap<Blacklist, DeleteBlacklistRequest>().ReverseMap();
        CreateMap<Blacklist, UpdateBlacklistRequest>().ReverseMap();

        CreateMap<Blacklist, CreatedBlacklistResponse>().ReverseMap();
        CreateMap<Blacklist, DeletedBlacklistResponse>().ReverseMap();
        CreateMap<Blacklist, UpdatedBlacklistResponse>().ReverseMap();
        CreateMap<Blacklist, GetAllBlacklistResponse>().ReverseMap();
        CreateMap<Blacklist, GetByIdBlacklistResponse>().ReverseMap();
    }
}
