using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YourAdventure;
using YourAdventure.BusinessLogic.Services.Interfaces;
using YourAdventure.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase 
{
    private readonly IConfiguration _configuration;
    private readonly ITokenGenerator _tokenGenerator;
    
    public UserController(IConfiguration configuration, ITokenGenerator tokenGenerator)
    {
        _configuration = configuration;
        _tokenGenerator = tokenGenerator;
    }

   
    

    [HttpPost("login")]
    public async Task<IActionResult> Login(Person model)
    {

        PersonController personController = new PersonController(_configuration);
        Person person = await personController.GetPerson(model.Email);
        //var user = _userService.GetUserInfo(model);

        // get user from DB to check if password is valid
        // if valid - return token
        // if not - return Authorized
        if (model.Nickname == person.Nickname && model.Password == person.Password )
        {
            var token = _tokenGenerator.GenerateToken(model);
            return Ok(token);

        }

        return Unauthorized();
    }
}
