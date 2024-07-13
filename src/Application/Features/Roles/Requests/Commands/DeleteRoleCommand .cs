using Application.Common;
using MediatR;

namespace Application.Features.Roles.Requests.Commands;

public record DeleteRoleCommand(string RoleName) : IRequest<BaseResponse<string>>;