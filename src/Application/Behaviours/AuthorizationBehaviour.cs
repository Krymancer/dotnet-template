using System.Reflection;
using Application.Common.Interfaces.Identity;
using Application.Security;
using MediatR;

namespace Application.Behaviours;

public class AuthorizationBehaviour<TRequest, TResponse>(
    IUser user,
    IIdentityService identityService)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>().ToList();

        if (authorizeAttributes.Count == 0) return await next();

        // Must be authenticated user
        if (user.Id == null) throw new UnauthorizedAccessException();

        var authorizeAttributesWithRoles =
            authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles)).ToList();

        if (authorizeAttributesWithRoles.Count != 0)
        {
            var authorized = false;

            foreach (var roles in authorizeAttributesWithRoles.Select(a => a.Roles.Split(',')))
            foreach (var role in roles)
            {
                var isInRole = await identityService.IsInRoleAsync(user.Id, role.Trim());
                if (!isInRole) continue;
                authorized = true;
                break;
            }

            // Must be a member of at least one role in roles
            if (!authorized) throw new UnauthorizedAccessException();
        }

        // Claims-based authorization
        var authorizeAttributesWithClaims =
            authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Claims)).ToList();

        if (!authorizeAttributesWithClaims.Any()) return await next();

        {
            var authorized = false;

            foreach (var claimTypeValuePairs in authorizeAttributesWithClaims.Select(a => a.Claims.Split(',')))
            foreach (var claimTypeValuePair in claimTypeValuePairs)
            {
                var parts = claimTypeValuePair.Trim().Split(':');
                if (parts.Length != 2) continue;
                var claimType = parts[0];
                var claimValue = parts[1];
                var hasClaim = await identityService.HasClaim(user.Id, claimType, claimValue);
                if (!hasClaim) continue;
                authorized = true;
                break;
            }

            // Must have at least one required claim
            if (!authorized) throw new UnauthorizedAccessException();
        }

        // User is authorized / authorization not required
        return await next();
    }
}