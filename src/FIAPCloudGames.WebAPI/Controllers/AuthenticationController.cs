using FIAPCloudGames.Domain.Requests;
using FIAPCloudGames.Domain.Responses;
using FIAPCloudGames.Domain.Services;
using FIAPCloudGames.WebAPI.Contracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FIAPCloudGames.WebAPI.Controllers;

public class AuthenticationController : ApiController
{
    private readonly IUserService _userService;

    public AuthenticationController(IUserService userService)
    {
        _userService = userService;
    }

    /// <summary>
    /// Realiza o login do usuário com e-mail e senha.
    /// </summary>
    /// <param name="loginRequest">Dados de autenticação (e-mail e senha).</param>
    /// <returns>Retorna o token JWT em caso de sucesso.</returns>
    /// <response code="200">Login realizado com sucesso. Retorna o token JWT.</response>
    /// <response code="400">Erro de validação ou credenciais inválidas.</response>
    [HttpPost(ApiRoutes.Authentication.Login)]
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var result = await _userService.Login(loginRequest);

        return Ok(result);
    }
}
