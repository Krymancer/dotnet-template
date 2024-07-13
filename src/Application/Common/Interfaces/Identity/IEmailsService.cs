namespace Application.Common.Interfaces.Identity;

public interface IEmailsService
{
    public Task<BaseResponse<string>> SendEmail(string email, string Message, string? reason);
}