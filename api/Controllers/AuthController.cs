using api.Services;
using Microsoft.AspNetCore.Mvc;
using shared;

namespace api.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthSessionDto>> Login(AuthLoginDto dto)
    {
        var session = await _authService.LoginByDni(dto.Dni);
        if (session == null)
            return Unauthorized(new { message = "Usuario no encontrado" });

        return Ok(session);
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto>> Register(AuthRegisterDto dto)
    {
        try
        {
            var user = await _authService.RegisterCitizen(dto);
            return Created($"api/users/{user.Id}", user);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
