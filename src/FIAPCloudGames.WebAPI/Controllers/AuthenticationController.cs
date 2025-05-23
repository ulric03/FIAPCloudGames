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

    [HttpPost(ApiRoutes.Authentication.Login)]
    [ProducesResponseType(typeof(TokenResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
    {
        var result = await _userService.Login(loginRequest);

        return Ok(result);
    }
}
