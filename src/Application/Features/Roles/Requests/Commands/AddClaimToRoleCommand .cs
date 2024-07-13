using Application.Common;
using MediatR;

namespace Application.Features.Roles.Requests.Commands;

public record AddClaimToRoleCommand(string RoleName, string ClaimType, string ClaimValue)
    : IRequest<BaseResponse<string>>;