using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using JwtAuthentification.Domain;
using JwtAuthentification.Infrastructure.Helpers;
using JwtAuthentification.Infrastructure.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthentification.Services.Identity;

public class IdentityService : IIdentityService
{
    private readonly JwtSettingOptions _jwtSettringOptions;

    public IdentityService(IOptions<JwtSettingOptions> jwtSettringOptions)
    {
        _jwtSettringOptions = jwtSettringOptions.Value;
    }

    // There are not realistic implemetation becouse I have no database and 
    // Microsoft Identity
    public Task<AuthentificationResult> RegisterAsync(string email, string password)
    {


        // TODO to implement user registration with DB


        byte[] key = _jwtSettringOptions.Secret.ConvertToAciiBytes();
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, email),
                new Claim("id", Guid.NewGuid().ToString()),
            }),

            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        return Task.FromResult(new AuthentificationResult
        {
            Success = true,
            Token = tokenHandler.WriteToken(token)
        });
    }
}
