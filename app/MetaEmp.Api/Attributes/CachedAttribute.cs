using MetaEmp.Core.Constants;
using Microsoft.AspNetCore.Mvc;

namespace MetaEmp.Api.Attributes;

public class CachedAttribute : ResponseCacheAttribute
{
    public CachedAttribute()
    {
        Duration = CacheDurations.Default;
    }
}