using Application.Common;
using MediatR;

namespace Application.Features.Roles.Requests.Queries;

public record GetRoleClaimsQuery(string RoleName) : IRequest<BaseResponse<IEnumerable<string>>>;