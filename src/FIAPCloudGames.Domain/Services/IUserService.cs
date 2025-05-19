using FIAPCloudGames.Domain.Requests;
using FIAPCloudGames.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAPCloudGames.Domain.Services;

public interface IUserService
{
    Task<UserResponse> Create(CreateUserRequest request);

    Task Update(UpdateUserRequest request);

    Task Delete(int id);

    Task<UserResponse> GetById(int id);

    Task<IEnumerable<UserResponse>> GetAll();

    Task Active(int id);

    Task Inactive(int id);

    Task<TokenResponse> Login(LoginRequest request);
}
