using FIAPCloudGames.Domain.Entities;

namespace FIAPCloudGames.Domain.Repositores;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> Login(string email, string password);
}
