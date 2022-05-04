using MediatR;
using MetaEmp.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MetaEmp.Application.Abstractions;

public abstract class AuthorizedRequestHandler<TRequest, TResult> : DbRequestHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>
{
    protected IUserProvider UserProvider;

    protected AuthorizedRequestHandler(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        UserProvider = serviceProvider.GetRequiredService<IUserProvider>();
    }

    public Task<TResult> Handle(TRequest request, CancellationToken cancel)
    {
        return Handle(request);
    }
}