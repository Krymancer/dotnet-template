using Application.Common;
using MediatR;

namespace Application.Features.Emails.Requests.Commands;

public record SendEmailCommand(string Email, string Message) : IRequest<BaseResponse<string>>;