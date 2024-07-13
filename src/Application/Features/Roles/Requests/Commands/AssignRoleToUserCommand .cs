using Application.Common;
using MediatR;

namespace Application.Features.Roles.Requests.Commands;

public record AssignRoleToUserCommand(string UserId, string RoleName) : IRequest<BaseResponse<string>>;