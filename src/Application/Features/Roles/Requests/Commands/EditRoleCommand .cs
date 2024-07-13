using Application.Common;
using MediatR;

namespace Application.Features.Roles.Requests.Commands;

public record EditRoleCommand(string RoleName, string NewRoleName) : IRequest<BaseResponse<string>>;