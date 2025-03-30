using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TaskManagement.Application.Identity;

namespace TaskManagement.Identity.Services;
public class UserService : IUserService
{

    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

}
