using FIAPCloudGames.Domain.Requests;
using FIAPCloudGames.Domain.Responses;
using FIAPCloudGames.Domain.Services;
using FIAPCloudGames.WebAPI.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FIAPCloudGames.WebAPI.Controllers;

public class UserController : ApiController
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Cria um novo usuário no sistema.
    /// </summary>
    /// <param name="createUserRequest">Dados do usuário a ser criado.</param>
    /// <returns>Retorna o usuário criado.</returns>
    /// <response code="201">Usuário criado com sucesso.</response>
    /// <response code="400">Erro de validação nos dados informados.</response>
    [HttpPost(ApiRoutes.Users.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest createUserRequest)
    {
        var result = await _userService.Create(createUserRequest);
        return Ok(result);
    }

    /// <summary>
    /// Atualiza os dados de um usuário existente.
    /// </summary>
    /// <param name="userId">ID do usuário.</param>
    /// <param name="updateUserRequest">Dados atualizados do usuário.</param>
    /// <returns>Confirmação da atualização.</returns>
    /// <response code="200">Usuário atualizado com sucesso.</response>
    /// <response code="400">Erro nos dados informados.</response>
    [HttpPut(ApiRoutes.Users.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int userId, [FromBody] UpdateUserRequest updateUserRequest)
    {
        updateUserRequest.Id = userId;
        await _userService.Update(updateUserRequest);
        return Ok();
    }

    /// <summary>
    /// Obtém os dados de um usuário pelo ID.
    /// </summary>
    /// <param name="userId">ID do usuário.</param>
    /// <returns>Dados do usuário.</returns>
    /// <response code="200">Usuário encontrado.</response>
    /// <response code="404">Usuário não encontrado.</response>
    [HttpGet(ApiRoutes.Users.GetById)]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int userId)
    {
        var result = await _userService.GetById(userId);
        return Ok(result);
    }

    /// <summary>
    /// Obtém a lista de todos os usuários.
    /// </summary>
    /// <returns>Lista de usuários.</returns>
    /// <response code="200">Lista retornada com sucesso.</response>
    /// <response code="404">Nenhum usuário encontrado.</response>
    [HttpGet(ApiRoutes.Users.GetAll)]
    [ProducesResponseType(typeof(IEnumerable<UserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _userService.GetAll();
        return Ok(result);
    }

    /// <summary>
    /// Ativa um usuário.
    /// </summary>
    /// <param name="userId">ID do usuário a ser ativado.</param>
    /// <returns>Confirmação da ativação.</returns>
    /// <response code="200">Usuário ativado com sucesso.</response>
    /// <response code="400">Erro ao ativar usuário.</response>
    [HttpPut(ApiRoutes.Users.Active)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Active(int userId)
    {
        await _userService.Active(userId);
        return Ok();
    }

    /// <summary>
    /// Inativa um usuário.
    /// </summary>
    /// <param name="userId">ID do usuário a ser inativado.</param>
    /// <returns>Confirmação da inativação.</returns>
    /// <response code="200">Usuário inativado com sucesso.</response>
    /// <response code="400">Erro ao inativar usuário.</response>
    [HttpPut(ApiRoutes.Users.Inactive)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Inactive(int userId)
    {
        await _userService.Inactive(userId);
        return Ok();
    }
}
