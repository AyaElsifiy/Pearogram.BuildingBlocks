using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pearogram.BuildingBlocks.Application.Dtos;
using Pearogram.BuildingBlocks.Application.Dtos.Authentication;
using Pearogram.BuildingBlocks.Domain.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pearogram.BuildingBlocks.Application.Helpers;

public static class JwtTokenHelper
{
    public static JwtSecurityToken GenerateToken(
        UserDto user,
        DateTime expiresAt,
        IConfiguration configuration)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        if (configuration == null) throw new ArgumentNullException(nameof(configuration));

        var jwtSettings = new JwtSettings(configuration);

        var claims = new List<Claim>
        {
            new Claim("user_id", user.Id.ToString()),
            new Claim("user_name", user.Name ?? string.Empty),
            new Claim("role_id", user.Role ?? string.Empty),
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        return new JwtSecurityToken(
            issuer: jwtSettings.Issuer,
            audience: jwtSettings.Audience,
            claims: claims,
            expires: expiresAt,
            signingCredentials: signingCredentials);
    }
}
