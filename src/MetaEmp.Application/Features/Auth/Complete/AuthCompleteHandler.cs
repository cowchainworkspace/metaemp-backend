using MediatR;
using MetaEmp.Application.Interfaces;
using MetaEmp.Core.Abstractions.Context;
using MetaEmp.Core.Exceptions;
using MetaEmp.Data.SqlSever.Entities;
using MetaEmp.Data.SqlSever.Extensions;
using Microsoft.AspNetCore.Identity;

namespace MetaEmp.Application.Features.Auth.Complete;

internal class AuthCompleteHandler : IRequestHandler<AuthCompleteCommand, AuthResult>
{
    private readonly IJwtService _jwtService;
    private readonly IDatabaseContext _database;
    private readonly SignInManager<AppUser> _signInManager;

    public AuthCompleteHandler(IJwtService jwtService, IDatabaseContext database, SignInManager<AppUser> signInManager)
    {
        _database = database;
        _jwtService = jwtService;
        _signInManager = signInManager;
    }

    public async Task<AuthResult> Handle(AuthCompleteCommand request, CancellationToken cancel)
    {
        //TODO: rewrite from login to sso
        //TODO: Write logic for <ValidateDidTokenAsync> method
        // links: [
        //     "https://github.com/magiclabs/magic-admin-php/blob/3dad1ae9b2f69b8239385b54ddc4ebb05b5f3a13/lib/Resource/Token.php#L83",
        //     "https://github.com/magiclabs/magic-admin-php/blob/3dad1ae9b2f69b8239385b54ddc4ebb05b5f3a13/lib/Util/Eth.php#L10",
        // ]

        var user = await _database.Set<AppUser>().GetByLoginAsync(request.Login, cancel: cancel);
        if (user is null) throw new NotFoundException("User not found.");

        return await PasswordAuthorizeAsync(user, request.Password!);
    }
    
    private async Task<AuthResult> PasswordAuthorizeAsync(AppUser user, string password)
    {
        var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!result.Succeeded) throw new ValidationFailedException("Invalid login or password.");

        return await _jwtService.GenerateAsync(user);
    }

    private async Task ValidateDidTokenAsync(string didToken)
    {
    }
}