using Application.Common;
using MediatR;

namespace Application.Features.Roles.Requests.Commands;

public record CreateRoleCommand(string RoleName) : IRequest<BaseResponse<string>>;