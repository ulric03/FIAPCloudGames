using FIAPCloudGames.Domain.Requests;
using FIAPCloudGames.Domain.Responses;
using FIAPCloudGames.Domain.Services;
using FIAPCloudGames.WebAPI.Contracts;
using FIAPCloudGames.WebAPI.Validators;
using FluentValidation;
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
        var validator = new CreateUserRequestValidator();
        var result = validator.Validate(createUserRequest);
        if (!result.IsValid)
            return Ok(result.ToDictionary());

        var user = await _userService.Create(createUserRequest);
        return Ok(user);
    }

    [HttpPut(ApiRoutes.Users.Update)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int userId, [FromBody] UpdateUserRequest updateUserRequest)
    {
        updateUserRequest.Id = userId;

        var validator = new UpdateUserRequestValidator();
        var result = validator.Validate(updateUserRequest);
        if (!result.IsValid)
            return Ok(result.ToDictionary());

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
