using Application.Common;
using MediatR;

namespace Application.Features.Roles.Requests.Queries;

public record GetAllRolesQuery : IRequest<BaseResponse<IEnumerable<string>>>;