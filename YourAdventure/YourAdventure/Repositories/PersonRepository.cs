using CurdOperationWithDapperNetCoreMVC_Demo.Data;
using CurdOperationWithDapperNetCoreMVC_Demo.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurdOperationWithDapperNetCoreMVC_Demo.Repositories
{
    public class PersonRepository : IPerson
    {
        private readonly DapperDbContext context;

        public PersonRepository(DapperDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<PersonModel>> Get()
        {
            var sql = $@"SELECT [PersonId],
                               [PersonNickname],
                               [PersonBirthday],
                               [PersonEmail],
                               [ProfilePicture],
                               [Password],
                               [SettingsId]
                        FROM [Persons]";

            using var connection = context.CreateConnection();
            return await connection.QueryAsync<PersonModel>(sql);
        }

        public async Task<PersonModel> Find(Guid uid)
        {
            var sql = $@"SELECT [PersonId],
                               [PersonNickname],
                               [PersonBirthday],
                               [PersonEmail],
                               [ProfilePicture],
                               [Password],
                               [SettingsId]
                        FROM [Persons]
                        WHERE [PersonId] = @uid";

            using var connection = context.CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<PersonModel>(sql, new { uid });
        }

        public async Task<PersonModel> Add(PersonModel model)
        {
            model.PersonId = Guid.NewGuid();
            var sql = $@"INSERT INTO [dbo].[Persons]
                                ([PersonId],
                                 [PersonNickname],
                                 [PersonBirthday],
                                 [PersonEmail],
                                 [ProfilePicture],
                                 [Password],
                                 [SettingsId])
                         VALUES
                                (@PersonId,
                                 @PersonNickname,
                                 @PersonBirthday,
                                 @PersonEmail,
                                 @ProfilePicture,
                                 @Password,
                                 @SettingsId)";

            using var connection = context.CreateConnection();
            await connection.ExecuteAsync(sql, model);
            return model;
        }

        public async Task<PersonModel> Update(PersonModel model)
        {
            var sql = $@"UPDATE [dbo].[Persons]
                            SET [PersonNickname] = @PersonNickname,
                                [PersonBirthday] = @PersonBirthday,
                                [PersonEmail] = @PersonEmail,
                                [ProfilePicture] = @ProfilePicture,
                                [Password] = @Password,
                                [SettingsId] = @SettingsId
                            WHERE [PersonId] = @PersonId";

            using var connection = context.CreateConnection();
            await connection.ExecuteAsync(sql, model);
            return model;
        }

        public async Task<PersonModel> Remove(PersonModel model)
        {
            var sql = $@"DELETE FROM [dbo].[Persons]
                        WHERE [PersonId] = @PersonId";

            using var connection = context.CreateConnection();
            await connection.ExecuteAsync(sql, model);
            return model;
        }
    }
}
