using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using YourAdventure.BusinessLogic.Services.Interfaces;
using YourAdventure;

public class PersonGenerator : IPersonGenerator
{
    private readonly IConfiguration _config;

    public PersonGenerator(IConfiguration config)
    {
        _config = config;
    }

    public async Task<List<Person>> GetAllPersons()
    {
        using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        var persons = await connection.QueryAsync<Person>("select * from person");
        return persons.AsList();
    }

    public async Task<Person> GetPerson(string Email)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        var person = await connection.QueryFirstOrDefaultAsync<Person>("select * from person where Email = @Email",
            new { Email = Email });
        return person;
    }

    public async Task<Person> NewPerson(Person person)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        await connection.ExecuteAsync("insert into Person (Nickname, Bday, Email, Profilepicture, Password)" +
            " values (@Nickname, @Bday, @Email, @Profilepicture, @Password)", person);
        return person;
    }

    public async Task<Person> UpdatePerson(Person person)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        await connection.ExecuteAsync("update Person set Nickname = @Nickname, Bday = @Bday, Email = @Email, Profilepicture = @Profilepicture, Password = @Password where PersonId = @PersonId", person);
        return person;
    }

    public async Task<List<Person>> DeletePerson(int PersonId)
    {
        using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
        await connection.ExecuteAsync("delete from Person where PersonId = @id", new { id = PersonId });
        return await GetAllPersons();
    }
}
