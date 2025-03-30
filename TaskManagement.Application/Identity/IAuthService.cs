using TaskManagement.Application.Models.Identity;

namespace TaskManagement.Application.Identity;
public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}
