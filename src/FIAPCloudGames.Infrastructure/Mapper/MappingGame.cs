using AutoMapper;
using FIAPCloudGames.Domain.Entities;
using FIAPCloudGames.Domain.Requests;
using FIAPCloudGames.Domain.Responses;

namespace FIAPCloudGames.Infrastructure.Mapper;

public class MappingGame : Profile
{
    public MappingGame()
    {
        CreateMap<CreateGameRequest, Game>().ReverseMap();
        CreateMap<UpdateGameRequest, Game>().ReverseMap();
        CreateMap<GameResponse, Game>().ReverseMap();
        CreateMap<IEnumerable<GameResponse>, Game>().ReverseMap();
    }
}