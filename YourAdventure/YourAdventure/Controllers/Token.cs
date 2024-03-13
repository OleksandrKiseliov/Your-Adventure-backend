using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public UserController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        // Additional properties as needed
    }
    public class TokenOptions
    {
        public string Secret { get; set; }
        public int ExpiryDays { get; set; }
        // Add any other properties you need for token configuration
    }

    [HttpPost("login")]
    public IActionResult Login(LoginModel model)
    {
        if (model.Username == "admin" && model.Password == "password" && model.Email == "email")
        {
            var tokenOptions = _configuration.GetSection("TokenOptions").Get<TokenOptions>();

            // Generate a secure 256-bit key
            var keyBytes = new byte[32];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyBytes);
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, model.Username)
                }),
                Expires = DateTime.UtcNow.AddDays(tokenOptions.ExpiryDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return Ok(new { token = tokenHandler.WriteToken(token) });
        }

        return Unauthorized();
    }
}
