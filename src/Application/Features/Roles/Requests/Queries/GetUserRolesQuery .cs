using Application.Common;
using MediatR;

namespace Application.Features.Roles.Requests.Queries;

public record GetUserRolesQuery(string UserId) : IRequest<BaseResponse<IEnumerable<string>>>;