using FluentValidation;
using MediatR;
using MetaEmp.Application.Extensions;

namespace MetaEmp.Application.Features.Auth.Check;

public class AuthCheckQuery : IRequest<AuthCheckResult>
{
	/// <example>aspadmin</example>
	public string Login { get; init; } = default!;
}

public class AuthCheckQueryValidator : AbstractValidator<AuthCheckQuery>
{
	public AuthCheckQueryValidator()
	{
		RuleFor(o => o.Login).NotEmpty().UserName();
	}
}