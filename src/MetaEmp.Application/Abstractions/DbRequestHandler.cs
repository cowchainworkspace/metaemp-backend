using MediatR;
using MetaEmp.Core.Abstractions.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace MetaEmp.Application.Abstractions;

public abstract class DbRequestHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult>
    where TRequest : IRequest<TResult>
{
    private readonly IServiceProvider _serviceProvider;

    protected readonly IDatabaseContext Context;
    protected HttpContext HttpContext => _serviceProvider.GetRequiredService<IHttpContextAccessor>().HttpContext!;

    protected DbRequestHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        Context = serviceProvider.GetRequiredService<IDatabaseContext>();
    }

    protected virtual Task<TResult> Handle(TRequest request)
    {
        throw new NotImplementedException();
    }

    public virtual Task<TResult> Handle(TRequest request, CancellationToken cancel)
    {
        return Handle(request);
    }
}