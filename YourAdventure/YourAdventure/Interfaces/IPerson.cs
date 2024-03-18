using CurdOperationWithDapperNetCoreMVC_Demo.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurdOperationWithDapperNetCoreMVC_Demo.Repositories
{
    public interface IPerson
    {
        Task<IEnumerable<PersonModel>> Get();
        Task<PersonModel> Find(Guid uid);
        Task<PersonModel> Add(PersonModel model);
        Task<PersonModel> Update(PersonModel model);
        Task<PersonModel> Remove(PersonModel model);
    }
}
