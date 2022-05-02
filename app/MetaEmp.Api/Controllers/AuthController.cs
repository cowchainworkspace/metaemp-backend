using MetaEmp.Api.Abstractions;
using MetaEmp.Application.Features.Auth;
using MetaEmp.Application.Features.Auth.Check;
using MetaEmp.Application.Features.Auth.Complete;
using MetaEmp.Application.Features.Auth.Refresh;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Controllers;

[AllowAnonymous]
public class AuthController : ApiController
{
	[HttpPost("complete")]
	public async Task<AuthResult> CompleteAsync([FromBody] AuthCompleteCommand command, CancellationToken cancel)
	{
		// TODO:
		// decode did
		// validate address with eth3
		// validate for timeout
		// generate our jwt token
		// return our jwt token
		
		return await Mediator.Send(command, cancel);
	}

	[HttpPut("refresh")]
	public async Task<AuthResult> RefreshAsync([FromBody] AuthRefreshCommand command, CancellationToken cancel) =>
			await Mediator.Send(command, cancel);
}