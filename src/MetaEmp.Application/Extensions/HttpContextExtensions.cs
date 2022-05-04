using Microsoft.AspNetCore.Http;

namespace MetaEmp.Application.Extensions;

public static class HttpContextExtensions
{
    /// <summary>
    /// Sets count of array elements to headers
    /// </summary>
    public static void SetCountHeader(this HttpContext httpContext, int count)
    {
        httpContext.Response.Headers["Count"] = count.ToString();
    }
}