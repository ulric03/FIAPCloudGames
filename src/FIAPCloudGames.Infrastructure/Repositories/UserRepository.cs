using AutoMapper;
using FIAPCloudGames.Domain.Entities;
using FIAPCloudGames.Domain.Repositores;
using Microsoft.EntityFrameworkCore;

namespace FIAPCloudGames.Infrastructure.Repositories;

public class UserRepository: BaseRepository<User>, IUserRepository
{
    private readonly FCGContext _dbContext;
    private readonly IMapper _mapper;

    public UserRepository(FCGContext _dbContext, IMapper mapper) : base(_dbContext)
    {
        this._dbContext = _dbContext;
        _mapper = mapper;
    }

    public async Task<bool> Login(string email, string password)
    {
        var result = await _dbContext.Users
            .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);

        if (result is null) 
            return false;

        return true;
    }
}
