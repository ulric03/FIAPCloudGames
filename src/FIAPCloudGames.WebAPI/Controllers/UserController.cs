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

    [HttpPost(ApiRoutes.Users.Create)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest createUserRequest)
    {
        var result = await _userService.Create(createUserRequest);
        return Ok(result);
    }

    [HttpPut(ApiRoutes.Users.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int userId, [FromBody] UpdateUserRequest updateUserRequest)
    {
        updateUserRequest.Id = userId;
        await _userService.Update(updateUserRequest);
        return Ok();
    }

    [HttpGet(ApiRoutes.Users.GetById)]
    [ProducesResponseType(typeof(UserResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int userId)
    {
        var result = await _userService.GetById(userId);
        return Ok(result);
    }

    [HttpGet(ApiRoutes.Users.GetAll)]
    [ProducesResponseType(typeof(IEnumerable<UserResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll()
    {
        var result = await _userService.GetAll();
        return Ok(result);
    }

    [HttpPut(ApiRoutes.Users.Active)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Active(int userId)
    {
        await _userService.Active(userId);
        return Ok();
    }

    [HttpPut(ApiRoutes.Users.Inactive)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Inactive(int userId)
    {
        await _userService.Inactive(userId);
        return Ok();
    }
}
