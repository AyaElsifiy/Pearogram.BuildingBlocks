using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.AspNetCore.Http;

namespace pearogram.BuildingBlocks.Application.Common.Interceptors;
public class ForwardHttpContextHeadersInterceptor : Interceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string[] _headersToForward = new[]
    {
        "authorization",
        "x-correlation-id",
        "x-session-id",
        "accept-language"
    };

    public ForwardHttpContextHeadersInterceptor(IHttpContextAccessor httpContextAccessor)
        => _httpContextAccessor = httpContextAccessor;

    private Metadata BuildMetadata()
    {
        var md = new Metadata();
        var httpContext = _httpContextAccessor.HttpContext;
        if (httpContext == null) return md;

        foreach (var header in _headersToForward)
        {
            if (httpContext.Request.Headers.TryGetValue(header, out var vals))
            {
                var v = vals.FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(v))
                    md.Add(header, v);
            }
        }

        if (!md.Any(h => h.Key == "x-correlation-id"))
            md.Add("x-correlation-id", System.Guid.NewGuid().ToString());

        return md;
    }

    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
        TRequest request,
        ClientInterceptorContext<TRequest, TResponse> context,
        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        var headers = context.Options.Headers ?? new Metadata();
        var forwarded = BuildMetadata();
        foreach (var h in forwarded)
            if (!headers.Any(x => x.Key == h.Key))
                headers.Add(h);

        var opt = context.Options.WithHeaders(headers);
        var newContext = new ClientInterceptorContext<TRequest, TResponse>(context.Method, context.Host, opt);
        return base.AsyncUnaryCall(request, newContext, continuation);
    }
}