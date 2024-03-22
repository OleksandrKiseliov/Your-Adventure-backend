using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using YourAdventure.BusinessLogic.Services.Interfaces;

namespace YourAdventure.BusinessLogic.Services;

public class TokenGenerator : ITokenGenerator
{
    private readonly IConfiguration _configuration;

    public TokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(Person model)
    {
        var tokenOptions = _configuration.GetSection("TokenOptions").Get<YourAdventure.TokenOptions>();

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.Secret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, model.Nickname)
        };

        var token = new JwtSecurityToken(
            issuer: tokenOptions.Issuer,
            audience: tokenOptions.Audience,
            claims: claims,
            expires: DateTime.Now.AddMonths(2),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

