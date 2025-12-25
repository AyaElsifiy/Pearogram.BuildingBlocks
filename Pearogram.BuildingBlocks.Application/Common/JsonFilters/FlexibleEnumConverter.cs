using System.Text.Json;
using System.Text.Json.Serialization;

namespace Pearogram.BuildingBlocks.Application.Common.JsonFilters;

public class FlexibleEnumConverter<T> : JsonConverter<T> where T : struct, Enum
{
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
     
        if (reader.TokenType == JsonTokenType.Number && reader.TryGetInt32(out int intValue))
        {
            if (Enum.IsDefined(typeof(T), intValue))
                return (T)Enum.ToObject(typeof(T), intValue);
        }
        else if (reader.TokenType == JsonTokenType.String)
        {
            var stringValue = reader.GetString();
            if (Enum.TryParse<T>(stringValue, true, out var result))
                return result;
        }

        throw new JsonException($"Unable to convert value to enum {typeof(T).Name}");
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}
