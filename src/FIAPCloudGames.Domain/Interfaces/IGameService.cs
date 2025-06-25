using FIAPCloudGames.Domain.Requests;
using FIAPCloudGames.Domain.Responses;

namespace FIAPCloudGames.Domain.Interfaces;

public interface IGameService
{
    Task<GameResponse> Create(CreateGameRequest request);

    Task Update(UpdateGameRequest request);

    Task<GameResponse> GetById(int id);

    Task<IEnumerable<GameResponse>> GetAll();

    Task Active(int id);

    Task Inactive(int id);
}
