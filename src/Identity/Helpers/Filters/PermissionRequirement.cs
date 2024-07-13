using Microsoft.AspNetCore.Authorization;

namespace CleanArchitecture.Identity.Helpers.Filters;

public class PermissionRequirement : IAuthorizationRequirement
{
    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }

    public string Permission { get; private set; }
}