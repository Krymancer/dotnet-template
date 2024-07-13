using Application.Common;
using Application.Features.Auth.Results;
using MediatR;

namespace Application.Features.Auth.Requests.Commands;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    string UserName,
    string Password
) : IRequest<BaseResponse<RegisterResult>>;