using Application.Common.Interfaces.Identity;

namespace Application.Features.Auth.Handlers.Queries;

internal class AuthQueryHandler(IAuthService authService)
{
    private readonly IAuthService _authService = authService;
}