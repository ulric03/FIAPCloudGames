using AutoMapper;
using FIAPCloudGames.Domain.Entities;
using FIAPCloudGames.Domain.Requests;
using FIAPCloudGames.Domain.Responses;

namespace FIAPCloudGames.Infrastructure.Mapper;

public class MappingUser : Profile
{
    public MappingUser()
    {
        CreateMap<CreateUserRequest, User>().ReverseMap();
        CreateMap<UpdateUserRequest, User>().ReverseMap();
        CreateMap<UserResponse, User>().ReverseMap();
        CreateMap<IEnumerable<UserResponse>, User>().ReverseMap();
    }
}