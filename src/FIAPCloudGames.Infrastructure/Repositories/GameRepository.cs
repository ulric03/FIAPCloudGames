using AutoMapper;
using FIAPCloudGames.Domain.Entities;
using FIAPCloudGames.Domain.Repositores;
using FIAPCloudGames.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FIAPCloudGames.Infrastructure.Repositories;

public class GameRepository: BaseRepository<Game>, IGameRepository
{
    private readonly FCGContext _dbContext;
    private readonly IMapper _mapper;

    public GameRepository(FCGContext _dbContext, IMapper mapper) : base(_dbContext)
    {
        this._dbContext = _dbContext;
        _mapper = mapper;
    }
}
