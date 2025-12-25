using Grpc.Core;
using Grpc.Core.Interceptors;


public class MapMetadataToHttpContextInterceptor : Interceptor
{
    private readonly string[] _keysToMap = new[]
    {
        "x-correlation-id",
        "x-session-id",
        "accept-language"
    };

    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        var httpContext = context.GetHttpContext();
        if (httpContext != null)
        {
            foreach (var md in context.RequestHeaders)
            {
                if (_keysToMap.Contains(md.Key))
                {
                    httpContext.Items[md.Key] = md.Value;
                }
            }
        }

        return await base.UnaryServerHandler(request, context, continuation);
    }
}