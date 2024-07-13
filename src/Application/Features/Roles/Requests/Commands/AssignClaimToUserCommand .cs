using Application.Common;
using MediatR;

namespace Application.Features.Roles.Requests.Commands;

public record AssignClaimToUserCommand(string UserId, string ClaimType, string ClaimValue)
    : IRequest<BaseResponse<string>>;