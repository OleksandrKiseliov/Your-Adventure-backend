using Microsoft.AspNetCore.Authorization;
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
public class TestController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public TestController(IConfiguration configuration)
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

    [HttpGet]
    [Authorize]
    public IActionResult Login()
    {
        return Ok();
    }
}
