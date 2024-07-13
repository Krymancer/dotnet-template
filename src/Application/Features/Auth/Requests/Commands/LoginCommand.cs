using Application.Common;
using Application.Features.Auth.Results;
using MediatR;

namespace Application.Features.Auth.Requests.Commands;

public record LoginCommand(string Email, string Password) : IRequest<BaseResponse<LoginResult>>;