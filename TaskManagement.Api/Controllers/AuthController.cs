using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Identity;
using TaskManagement.Application.Models.Identity;

namespace TaskManagement.Api.Controllers;

[Route("api/[controller]")]
    [ApiController]
public class AuthController : ControllerBase
{
    public readonly IAuthService _authenticationService;

    public AuthController(IAuthService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
    {
        return Ok(await _authenticationService.Login(request));
    }

    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
    {
        return Ok(await _authenticationService.Register(request));
    }
}
