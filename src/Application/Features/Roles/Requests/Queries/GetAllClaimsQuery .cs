using Application.Common;
using MediatR;

namespace Application.Features.Roles.Requests.Queries;

public record GetAllClaimsQuery : IRequest<BaseResponse<IEnumerable<string>>>;