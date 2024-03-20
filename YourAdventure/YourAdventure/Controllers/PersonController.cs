using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace YourAdventure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IConfiguration _config;
        public PersonController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetAllPersons()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var persons = await connection.QueryAsync<Person>("select * from person");
            return Ok(persons);
        }

        [HttpGet("{Email}")]
        public async Task<Person> GetPerson(string Email)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var person = await connection.QueryFirstAsync<Person>("select * from person where Email = @Email",
                new { Email = Email });
            return (person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> NewPerson(Person person)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into Person (Nickname, Bday, Email, Profilepicture, Password)" +
                " values (@Nickname, @Bday, @Email, @Profilepicture, @Password)", person);
            return Ok(await GetAllPersons());
        }

        [HttpPut]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person person)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update Person set Nickname = @Nickname, Bday = @Bday, Email = @Email, Profilepicture = @Profilepicture, Password = @Password where PersonId = @PersonId", person);
            return Ok(person);
        }

        [HttpDelete("{PersonId}")]
        public async Task<ActionResult<List<Person>>> DeletePerson(int PersonId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from Person where PersonId = @id", new { id = PersonId });
            return Ok(await GetAllPersons());
        }


    }
}
