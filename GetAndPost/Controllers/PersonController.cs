
using GetAndPost.Models;
using GetAndPost.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetAndPost.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPerson _PersonRepository;

        public PersonController(IPerson person)
        {
            _PersonRepository = person;
        }

        [HttpGet]
        public async Task<IEnumerable<Person>> GetPersons()
        {
            return await _PersonRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPersons(int id)
        {
            return await _PersonRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> PostPersons([FromBody] Person person)
        {
            var newPerson = await _PersonRepository.Create(person);
            return CreatedAtAction(nameof(GetPersons), new { id = newPerson.Id }, newPerson);
        }

        [HttpPut]
        public async Task<ActionResult> PutPersons(int id, [FromBody] Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            await _PersonRepository.Update(person);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var bookToDelete = await _PersonRepository.Get(id);
            if (bookToDelete == null)
                return NotFound();

            await _PersonRepository.Delete(bookToDelete.Id);
            return NoContent();
        }

        [HttpGet]
        [Route("/Url")]
        public async Task<string> GetByUrl()
        {
            return await _PersonRepository.GetByUrl();
        }
    }
}

