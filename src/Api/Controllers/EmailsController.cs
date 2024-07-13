using Api.Common;
using Application.Features.Emails.Requests.Commands;
using Domain.MetaData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Authorize(Roles = "Administrator")]
public class EmailsController(ISender mediator) : BaseController
{
    [HttpPost(Router.EmailsRoute.Actions.SendEmail)]
    public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
    {
        return CustomResult(await mediator.Send(command));
    }
}