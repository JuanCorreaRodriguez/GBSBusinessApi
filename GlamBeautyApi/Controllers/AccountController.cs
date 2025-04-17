using GlamBeautyApi.Dtos.Account;
using GlamBeautyApi.Entities;
using GlamBeautyApi.Interfaces.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GlamBeautyApi.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly SignInManager<AppUser> _signInManager;
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;

    public AccountController(UserManager<AppUser> userManager, ITokenService tokenService,
        SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _signInManager = signInManager;
    }

    [Route("/signup")]
    [HttpPost]
    public async Task<IActionResult> SignUp([FromBody] SignUpDto dto)
    {
        try
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = new AppUser { UserName = dto.Username, Email = dto.Email, PhoneNumber = dto.Phone };

            var user = await _userManager.CreateAsync(appUser, dto.Password);

            if (!user.Succeeded) return StatusCode(500, user.Errors);

            var roleResult = await _userManager.AddToRoleAsync(appUser, dto.Role);

            return roleResult.Succeeded
                ? Ok(new AuthNewUser
                {
                    Email = appUser.Email,
                    Username = appUser.UserName,
                    Token = _tokenService.CreateToken(appUser)
                })
                : StatusCode(500, roleResult.Errors);
        }
        catch (Exception e)
        {
            return StatusCode(500, e);
        }
    }

    [HttpPost("/signin")]
    public async Task<IActionResult> SignIn(SignInDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.Users.FirstOrDefaultAsync(p => p.UserName == dto.Username);

        if (user == null) return Unauthorized("Invalid username");

        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);

        if (!result.Succeeded) return Unauthorized("Invalid password");

        return Ok(
            new AuthNewUser
            {
                Email = user.Email!,
                Username = user.UserName!,
                Token = _tokenService.CreateToken(user)
            }
        );
    }

    // {
    //     "username": "codelistudio1",
    //     "email": "codeli@codelistudio.com",
    //     "token": "eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJlbWFpbCI6ImNvZGVsaUBjb2RlbGlzdHVkaW8uY29tIiwiZ2l2ZW5fbmFtZSI6ImNvZGVsaXN0dWRpbzEiLCJuYmYiOjE3NDM5NjcyNjQsImV4cCI6MTc0NDU3MjA2NCwiaWF0IjoxNzQzOTY3MjY0LCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MjEzIiwiYXVkIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzIxMyJ9.SrUTbUTb33Q2yptPWmVZ5nK9mrTLgPZrAPYOJ3GpXtA4WUXYoxCZLs95rEKAPEgXe9_yerVb4b-tFOTZfliMNQ"
    // }
}