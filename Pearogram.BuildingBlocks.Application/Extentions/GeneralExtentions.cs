using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Pearogram.BuildingBlocks.Application.Extentions;

public static class GeneralExtentions
{
    public static string GetUserId(this HttpContext httpContext)
    {
        if (httpContext.User == null || httpContext.User.Claims.Count() == 0)
        {
            return string.Empty;
        }
        return httpContext.User.Claims.Single(x => x.Type == "user_id").Value;
    }
    public static string GetUserName(this HttpContext httpContext)
    {
        if (httpContext.User == null || httpContext.User.Claims.Count() == 0)
        {
            return string.Empty;
        }
        return httpContext.User?.Claims.FirstOrDefault(x => x.Type == "user_name")?.Value ?? string.Empty;
    }
    public static Guid? GetUserRoles(this HttpContext httpContext)
    {
        if (httpContext?.User == null || !httpContext.User.Identity.IsAuthenticated)
            return null;
        return httpContext.User.Claims
            .Where(c => c.Type == ClaimTypes.Role)
            .Select(c => Guid.TryParse(c.Value, out var roleId) ? roleId : Guid.Empty)
            .Where(g => g != Guid.Empty)
            .FirstOrDefault();
    }
    public static string? GetUserRole(this HttpContext httpContext)
    {
        if (httpContext?.User == null || !httpContext.User.Identity.IsAuthenticated)
            return null;

        return httpContext.User.Claims
                    .FirstOrDefault(c => c.Type == "user_type")
                    ?.Value;
    }
}