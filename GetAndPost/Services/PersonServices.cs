using GetAndPost.Models;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetAndPost.Services
{
    public class PersonServices : IPerson 
    {
        private const bool V = true;
        private readonly Context _context;


        public PersonServices(Context context)
        {
            _context = context;
        }
        public async Task<Person> Create(Person people)
        {
            _context.Personnes.Add(people);
            await _context.SaveChangesAsync();

            return people;
        }

        public async Task Delete(int id)
        {
            var PersonToDelete = await _context.Personnes.FindAsync(id);
            _context.Personnes.Remove(PersonToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Person>> Get()
        {
            return await _context.Personnes.ToListAsync();
        }

        public async Task<Person> Get(int id)
        {
            return await _context.Personnes.FindAsync(id);
        }

        public async Task Update(Person people)
        {
            _context.Entry(people).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<string> GetByUrl()
        {
            var p1 = new Person().FirstName;
            
            
            var client = new HttpClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://cat-fact.herokuapp.com/facts"),
                Method = HttpMethod.Get,
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
               
                await _context.SaveChangesAsync();
                // if (String.Equals(body, p1))
                // return true;
                //else
                // return false;
                return body;
            }
        }
       // public async Task<Person> Checking(string name)
        //{
        //    var value = await _context.Personnes.FindAsync();
        //}
    }
}
