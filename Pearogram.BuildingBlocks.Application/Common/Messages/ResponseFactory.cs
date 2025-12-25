using Pearogram.BuildingBlocks.Application.Communications;
using System.Net;

namespace Pearogram.BuildingBlocks.Application.Common.Messages;

public static class ResponseFactory
{
    public static GeneralResponse<T> NotFound<T>(string entityName, string fieldName, object id)
    {
        var code = $"{entityName.ToUpperInvariant()}_NOT_FOUND";
        var errors = new Dictionary<string, string[]>
        {
            { fieldName, new[] { $"{entityName} with ID '{id}' was not found." } }
        };

        return new GeneralResponse<T>(
            ErrorMessages.EntityNotFound,
            HttpStatusCode.NotFound,
            code,
            errors
        );
    }
    public static GeneralResponse<T> BadRequest<T>(string code, string message, Dictionary<string, string[]>? errors = null) 
        => new GeneralResponse<T>(message, HttpStatusCode.BadRequest, code, errors);

    // General
    public static GeneralResponse<T> BadRequest<T>(string code, string singleErrorMessage, string field = "General")
     => new GeneralResponse<T>(
         ErrorMessages.OperationFailed,
         HttpStatusCode.BadRequest,
         code,
         new Dictionary<string, string[]> { { field, new[] { singleErrorMessage } } });
    // Domain - Helper 
    public static GeneralResponse<T> FromFailure<T>(string code, string errorMessage, string field = "General")
        => BadRequest<T>(code, errorMessage, field);
}