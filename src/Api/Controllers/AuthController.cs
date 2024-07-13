using Api.Common;
using Application.Features.Auth.Requests.Commands;
using Domain.MetaData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[AllowAnonymous]
[ApiController]
public class AuthController(ISender mediator) : BaseController
{
    [HttpPost(Router.AuthRouting.Actions.Login)]
    public async Task<IActionResult> Login([FromBody] LoginCommand request)
    {
        return CustomResult(await mediator.Send(request));
    }

    [HttpPost(Router.AuthRouting.Actions.Register)]
    public async Task<IActionResult> Register([FromBody] RegisterCommand request)
    {
        return CustomResult(await mediator.Send(request));
    }

    [HttpPost(Router.AuthRouting.Actions.SendResetPasswordCode)]
    public async Task<IActionResult> SendResetPassword([FromQuery] SendResetPasswordCommand command)
    {
        var response = await mediator.Send(command);
        return CustomResult(response);
    }

    [HttpPost(Router.AuthRouting.Actions.ResetPassword)]
    public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordCommand command)
    {
        var response = await mediator.Send(command);
        return CustomResult(response);
    }
}