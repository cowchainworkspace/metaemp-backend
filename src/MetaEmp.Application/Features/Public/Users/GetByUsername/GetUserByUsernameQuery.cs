using FluentValidation;
using MediatR;
using MetaEmp.Application.Extensions;

namespace MetaEmp.Application.Features.Public.Users.GetByUsername;

public class GetUserByUsernameQuery : IRequest<User>
{
	/// <example>aspadmin</example>
	public string Username { get; init; }


	public GetUserByUsernameQuery(string username)
	{
		Username = username;
	}
}

public class GetUserByUsernameQueryValidator : AbstractValidator<GetUserByUsernameQuery>
{
	public GetUserByUsernameQueryValidator()
	{
		RuleFor(o => o.Username).NotEmpty().UserName();
	}
}