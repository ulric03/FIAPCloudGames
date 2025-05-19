using FIAPCloudGames.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.Repositores;

public interface IUserRepository: IBaseRepository<User>
{
    Task<bool> Login(string email, string password);
}
