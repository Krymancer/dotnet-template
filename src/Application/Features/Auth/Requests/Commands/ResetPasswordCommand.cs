using Application.Common;
using MediatR;

namespace Application.Features.Auth.Requests.Commands;

public record ResetPasswordCommand(
    string Email,
    string Password,
    string ConfirmPassword,
    string Code) : IRequest<BaseResponse<string>>;