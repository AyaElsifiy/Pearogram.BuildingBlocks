using MediatR;
using Microsoft.AspNetCore.Http;
using Pearogram.BuildingBlocks.Domain.Contract;

namespace Pearogram.BuildingBlocks.Application.Common.Behaviours;

public class UserContextBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContextBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (request is IUserInfo userContext)
        {
            var httpContext = _httpContextAccessor.HttpContext;
            var userIdStr = httpContext?.User?.Claims?.FirstOrDefault(x => x.Type == "user_id")?.Value;


            if (Guid.TryParse(userIdStr, out var userId))
                userContext.UserId = userId;

            userContext.UserName = httpContext?.User?.Claims.FirstOrDefault(x => x.Type == "user_name")?.Value ?? string.Empty;
        }

        return await next();
    }
}
