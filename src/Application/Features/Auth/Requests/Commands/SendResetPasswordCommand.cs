using Application.Common;
using MediatR;

namespace Application.Features.Auth.Requests.Commands;

public record SendResetPasswordCommand(string Email) : IRequest<BaseResponse<string>>;