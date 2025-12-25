using Microsoft.Extensions.Configuration;

namespace Pearogram.BuildingBlocks.Application.Dtos.Authentication;

public class JwtSettings
{
    public string Key { get; }
    public string Issuer { get; }
    public string Audience { get; }
    public bool ValidateIssuer { get; }
    public bool ValidateAudience { get; }
    public bool ValidateIssuerSigningKey { get; }
    public bool ValidateLifeTime { get; }

    public JwtSettings(IConfiguration config)
    {
        Key = config["JwtSettings:Key"] ?? throw new ArgumentNullException("Jwt Key is missing");
        Issuer = config["JwtSettings:Issuer"] ?? string.Empty;
        Audience = config["JwtSettings:Audience"] ?? string.Empty;
        ValidateIssuer = bool.Parse(config["JwtSettings:ValidateIssuer"] ?? "true");
        ValidateAudience = bool.Parse(config["JwtSettings:ValidateAudience"] ?? "true");
        ValidateIssuerSigningKey = bool.Parse(config["JwtSettings:ValidateIssuerSigningKey"] ?? "true");
        ValidateLifeTime = bool.Parse(config["JwtSettings:ValidateLifeTime"] ?? "true");
    }
}
