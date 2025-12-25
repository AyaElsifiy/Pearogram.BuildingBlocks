using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pearogram.BuildingBlocks.Application.Communications;

public class GeneralResponse<T>
{
    public GeneralResponse(T resource, string message = "Success", int Count = 0)
    {
        Success = true;
        Message = message;
        Resource = resource;
        ResourceCount = Count;
        StatusCode = HttpStatusCode.OK;
    }

    public GeneralResponse(string message, HttpStatusCode statusCode,
        string? code = null, Dictionary<string, string[]>? errors = null)
    {
        Success = false;
        Message = message;
        Resource = default;
        StatusCode = statusCode;
        Code = code;
        Errors = errors;
    }

    public bool Success { get; set; }
    public string Message { get; set; }

    [JsonIgnore]
    public HttpStatusCode StatusCode { get; set; }

    [JsonPropertyName("status")]
    public int Status => (int)StatusCode;

    public T? Resource { get; set; }
    public int ResourceCount { get; set; }
    public string? Code { get; set; }
    public Dictionary<string, string[]>? Errors { get; set; }
}