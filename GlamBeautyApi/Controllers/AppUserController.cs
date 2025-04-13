﻿using GlamBeautyApi.Dtos.AppUser;
using GlamBeautyApi.Interfaces.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GlamBeautyApi.Controllers;

[Route("api/users")]
[ApiController]
public class AppUserController : ControllerBase
{
    private readonly IAppUserService _appUserService;

    public AppUserController(IAppUserService service)
    {
        _appUserService = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var usersDto = await _appUserService.GetAllUsers();
        return Ok(usersDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser([FromRoute] string id)
    {
        var user = await _appUserService.GetUser(id);

        if (user == null) return NotFound();

        return Ok(user);
    }

    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateUser([FromRoute] string id, [FromBody] AppUserUpdateDto dto)
    {
        var userModel = await _appUserService.UpdateUser(id, dto);

        if (userModel == null) return NotFound();

        return Ok(userModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] string id)
    {
        var userModel = await _appUserService.DeleteUser(id);

        if (userModel == null) return NotFound();

        return NoContent();
    }
}