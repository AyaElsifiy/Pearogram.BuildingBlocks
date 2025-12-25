using Microsoft.AspNetCore.Http;
using Pearogram.BuildingBlocks.Domain.Contract;
using Pearogram.BuildingBlocks.Domain.Enums;

namespace Pearogram.BuildingBlocks.Application.Helpers;

public class LanguageContext : ILanguageContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LanguageContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public ELanguageCode GetCurrentLanguage()
    {
        var langHeader = _httpContextAccessor.HttpContext?.Request.Headers["Accept-Language"].ToString();
        return Enum.TryParse<ELanguageCode>(langHeader, true, out var lang) ? lang : ELanguageCode.En;
    }
}

