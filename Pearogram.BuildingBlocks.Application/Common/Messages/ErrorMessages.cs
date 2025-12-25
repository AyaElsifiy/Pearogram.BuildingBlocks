namespace Pearogram.BuildingBlocks.Application.Common.Messages;

/// <summary>Centralized standard messages (expand later as needed).</summary>
public static class ErrorMessages
{
    // General Application Errors
    public const string Success = "Success";
    public const string UnexpectedError = "An unexpected error occurred.";
    public const string OperationFailed = "The operation failed to complete.";
    public const string InternalServerError = "An internal server error occurred.";
    public const string InvalidOperation = "The requested operation is not valid.";

    // Authentication & Authorization
    public const string Unauthorized = "You are not authorized to perform this action.";
    public const string InvalidToken = "Invalid or malformed token.";
    public const string TokenExpired = "Your session has expired. Please login again.";
    public const string Forbidden = "Access to this resource is forbidden.";
    public const string InvalidCredentials = "Invalid username or password.";

    // Entity/Resource Errors
    public const string EntityNotFound = "The requested resource was not found.";
    public const string EntityAlreadyExists = "The resource already exists.";
    public const string EntityCannotBeDeleted = "The resource cannot be deleted due to existing dependencies.";
    public const string EntityCannotBeUpdated = "The resource cannot be updated at this time.";

    // File Operations
    public const string FileNotFound = "The specified file was not found.";
    public const string InvalidFileFormat = "Invalid file format.";
    public const string FileSizeExceeded = "The selected image is too large. Please upload a file smaller than 5 MB.";
    public const string FileUploadFailed = "File upload failed.";

    // Database Operations
    public const string DatabaseConnectionFailed = "Failed to connect to the database.";
    public const string DatabaseOperationFailed = "Database operation failed.";
    public const string ConcurrencyConflict = "The record has been modified by another user. Please refresh and try again.";
    public const string ForeignKeyConstraintViolation = "Cannot perform this operation due to existing related data.";

    // Validation Errors
    public const string ValidationFailed = "Validation failed.";
    public const string InvalidInputData = "Invalid input data. Please check your request.";
    public const string RequiredFieldMissing = "Required field is missing.";
    public const string InvalidFormat = "Invalid format provided.";


}