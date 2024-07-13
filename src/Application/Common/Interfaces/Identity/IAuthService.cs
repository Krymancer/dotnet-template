using Application.Features.Auth.Requests.Commands;
using Application.Features.Auth.Results;

namespace Application.Common.Interfaces.Identity;

public interface IAuthService
{
    Task<BaseResponse<LoginResult>> Login(LoginCommand request);
    Task<BaseResponse<RegisterResult>> Register(RegisterCommand request);
    Task<BaseResponse<string>> SendResetPasswordCode(string email);
    Task<BaseResponse<string>> ConfirmAndResetPassword(string code, string email, string newPassword);
}