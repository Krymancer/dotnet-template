using Application.Common;
using Application.Common.Interfaces.Identity;
using CleanArchitecture.Identity.Helpers;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Localization;
using MimeKit;

namespace Identity.Services;

public class EmailsService : BaseResponseHandler, IEmailsService
{
    private readonly EmailSettings _emailSettings;
    private readonly IStringLocalizer<EmailsService> _localizer;

    public EmailsService(EmailSettings emailSettings, IStringLocalizer<EmailsService> localizer) : base(localizer)
    {
        _emailSettings = emailSettings;
        _localizer = localizer;
    }

    public async Task<BaseResponse<string>> SendEmail(string email, string message, string? reason)
    {
        try
        {
            // Sending a professional and customized email
            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, true);
                client.Authenticate(_emailSettings.FromEmail, _emailSettings.Password);

                // Create a more customized email body
                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = $"<p>{_localizer["DearUser"]},</p>" +
                               $"<p>{message}</p>" +
                               $"<p>{_localizer["BestRegards"]},<br/>{_localizer["CompanyName"]}</p>",
                    TextBody =
                        $"Dear User,{Environment.NewLine}{message}{Environment.NewLine}Best Regards,{Environment.NewLine}CompanyName"
                };

                var mimeMessage = new MimeMessage
                {
                    Body = bodyBuilder.ToMessageBody()
                };

                mimeMessage.From.Add(new MailboxAddress(_localizer["CompanyName"], _emailSettings.FromEmail));
                mimeMessage.To.Add(new MailboxAddress(_localizer["RecipientName"], email));
                mimeMessage.Subject = reason == null ? _localizer["NoSubmitted"] : reason;

                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }

            // End of sending email
            return Success<string>(_localizer["Success"]);
        }
        catch (Exception ex)
        {
            return BadRequest<string>(_localizer["Failed"]);
        }
    }
}