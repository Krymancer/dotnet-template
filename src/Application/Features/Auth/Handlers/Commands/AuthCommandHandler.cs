using Application.Common;
using Application.Common.Interfaces.Identity;
using Application.Features.Auth.Requests.Commands;
using Application.Features.Auth.Results;
using MediatR;

namespace Application.Features.Auth.Handlers.Commands;

public class AuthCommandHandler : IRequestHandler<LoginCommand, BaseResponse<LoginResult>>,
    IRequestHandler<RegisterCommand, BaseResponse<RegisterResult>>,
    IRequestHandler<SendResetPasswordCommand, BaseResponse<string>>,
    IRequestHandler<ResetPasswordCommand, BaseResponse<string>>
{
    private readonly IAuthService _authService;

    public AuthCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<BaseResponse<LoginResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        return await _authService.Login(request);
    }

    public async Task<BaseResponse<RegisterResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return await _authService.Register(request);
    }

    public async Task<BaseResponse<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        return await _authService.ConfirmAndResetPassword(request.Code, request.Email, request.Password);
    }

    public async Task<BaseResponse<string>> Handle(SendResetPasswordCommand request,
        CancellationToken cancellationToken)
    {
        return await _authService.SendResetPasswordCode(request.Email);
    }
}