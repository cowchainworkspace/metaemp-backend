using MetaEmp.Application.Interfaces;
using MetaEmp.Core.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace MetaEmp.Infrastructure.Services;

[Inject]
public class UserProvider : IUserProvider
{
    private readonly IHttpContextAccessor _accessor;

    public UserProvider(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }
    
}