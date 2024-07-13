using System.Reflection;
using Application.Common.Interfaces.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace Application.Behaviours;

public class AuthorizationJwtBehaviour<TRequest, TResponse>(
    IUser user,
    IIdentityService identityService,
    IHttpContextAccessor httpContextAccessor)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

        if (!authorizeAttributes.Any()) return await next();
        var token = httpContextAccessor.HttpContext?.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ")
            .Last();
        if (string.IsNullOrEmpty(token) || !await identityService.ValidateToken(token))
            throw new UnauthorizedAccessException();

        // User is authorized / authorization not required
        return await next();
    }
}