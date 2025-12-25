using Microsoft.AspNetCore.Http;
using Pearogram.BuildingBlocks.Domain.Contract;

namespace Pearogram.BuildingBlocks.Persistence.ServiceConfigurations;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? UserId =>
      _httpContextAccessor?.HttpContext?.User?.Claims?.SingleOrDefault(x => x.Type == "user_id")?.Value is string id && Guid.TryParse(id, out var guid)
      ? guid
      : null;
}
