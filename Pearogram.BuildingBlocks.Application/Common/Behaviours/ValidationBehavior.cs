using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using Pearogram.BuildingBlocks.Application.Common.Messages;
using Pearogram.BuildingBlocks.Application.Communications;
using System.Net;

namespace Pearogram.BuildingBlocks.Application.Common.Behaviours;

//public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//        where TResponse : class
//{
//    private readonly IEnumerable<IValidator<TRequest>> _validators;

//    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
//    {
//        _validators = validators;
//    }

//    public async Task<TResponse> Handle(
//        TRequest request,
//        RequestHandlerDelegate<TResponse> next,
//        CancellationToken cancellationToken)
//    {
//        if (!_validators.Any())
//            return await next();

//        var context = new ValidationContext<TRequest>(request);

//        var validationResults = await Task.WhenAll(
//            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

//        var failures = validationResults
//            .SelectMany(r => r.Errors)
//            .Where(f => f is not null)
//            .ToList();

//        if (!failures.Any())
//            return await next();

//        var errorsDict = failures
//            .GroupBy(f => f.PropertyName)
//            .ToDictionary(
//                g => g.Key,
//                g => g.Select(x => x.ErrorMessage).ToArray()
//            );

//        var responseType = typeof(TResponse);
//        if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(GeneralResponse<>))
//        {
//            var errorResponse = Activator.CreateInstance(
//                responseType,
//                ErrorMessages.InvalidInputData,          // message
//                HttpStatusCode.BadRequest,               // status
//                "VALIDATION_FAILED",                     // code
//                errorsDict                               // errors
//            );

//            return (TResponse)errorResponse!;
//        }

//        throw new ValidationException(string.Join(" | ", failures.Select(x => x.ErrorMessage)));
//    }
//}


//public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
//where TResponse : class
//{
//    private readonly IEnumerable<IValidator<TRequest>> _validators;

//    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
//    {
//        _validators = validators;
//    }

//    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
//        CancellationToken cancellationToken
//        )
//    {
//        if (_validators.Any())
//        {
//            var context = new ValidationContext<TRequest>(request);

//            var validationResults = await Task.WhenAll(
//                _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

//            var failures = validationResults
//                .SelectMany(r => r.Errors)
//                .Where(f => f != null)
//                .ToList();

//            if (failures.Any())
//            {
//                var message = string.Join(" | ", failures.Select(x => x.ErrorMessage));

//                var responseType = typeof(TResponse);

//                if (responseType.IsGenericType &&
//                    responseType.GetGenericTypeDefinition() == typeof(GeneralResponse<>))
//                {
//                    var errorResponse = Activator.CreateInstance(responseType, new object[] { message, HttpStatusCode.BadRequest });

//                    return (TResponse)errorResponse!;
//                }

//                throw new ValidationException(message);
//            }
//        }

//        return await next();
//    }
//}
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TResponse : class
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;

    public ValidationBehavior(
        IEnumerable<IValidator<TRequest>> validators,
        ILogger<ValidationBehavior<TRequest, TResponse>> logger)
    {
        _validators = validators;
        _logger = logger;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            _logger.LogDebug("No validators found for {RequestType}. Continuing to next handler.", typeof(TRequest).Name);
            return await next();
        }

        _logger.LogInformation("Starting validation for {RequestType} with {ValidatorCount} validators.",
            typeof(TRequest).Name, _validators.Count());

        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f is not null)
            .ToList();

        if (!failures.Any())
        {
            _logger.LogInformation("Validation succeeded for {RequestType}.", typeof(TRequest).Name);
            return await next();
        }

        _logger.LogWarning(
            "Validation failed for {RequestType} with {ErrorCount} error(s): {Errors}",
            typeof(TRequest).Name,
            failures.Count,
            string.Join(" | ", failures.Select(x => $"{x.PropertyName}: {x.ErrorMessage}"))
        );

        var errorsDict = failures
            .GroupBy(f => f.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.ErrorMessage).ToArray()
            );

        var responseType = typeof(TResponse);
        if (responseType.IsGenericType && responseType.GetGenericTypeDefinition() == typeof(GeneralResponse<>))
        {
            var errorResponse = Activator.CreateInstance(
                responseType,
                ErrorMessages.InvalidInputData,          // message
                HttpStatusCode.BadRequest,               // status
                "VALIDATION_FAILED",                     // code
                errorsDict                               // errors
            );

            _logger.LogDebug("Returning validation error response for {RequestType}.", typeof(TRequest).Name);
            return (TResponse)errorResponse!;
        }

        _logger.LogError("ValidationException thrown for {RequestType}: {Errors}",
            typeof(TRequest).Name,
            string.Join(" | ", failures.Select(x => x.ErrorMessage)));

        throw new ValidationException(string.Join(" | ", failures.Select(x => x.ErrorMessage)));
    }
}