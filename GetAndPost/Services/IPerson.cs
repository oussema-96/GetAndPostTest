using GetAndPost.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetAndPost.Services
{
    public interface IPerson
    {
        Task<IEnumerable<Person>> Get();
        Task<Person> Get(int id);
        Task<Person> Create(Person people);
        Task Update(Person people);
        Task Delete(int id);
        Task<string> GetByUrl();
        //Task<bool> Checking(string stringToCheck);
    }
}
