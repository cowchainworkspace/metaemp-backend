using FluentValidation;
using MediatR;
using MetaEmp.Application.Extensions;

namespace MetaEmp.Application.Features.Public.Auth.Check;

public class AuthCheckRequest : IRequest<AuthCheckResult>
{
	/// <example>aspadmin</example>
	public string Login { get; init; } = default!;
}

public class AuthCheckRequestValidator : AbstractValidator<AuthCheckRequest>
{
	public AuthCheckRequestValidator()
	{
		RuleFor(o => o.Login).NotEmpty().UserName();
	}
}