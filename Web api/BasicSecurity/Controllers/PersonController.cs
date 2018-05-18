using BasicSecurity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BasicSecurity.Data.DomainClasses;

namespace BasicSecurity.Controllers
{
    public class PersonController : ApiController
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        // GET: api/Person
        public IHttpActionResult Get()
        {
            return Ok(_personRepository.GetAll());
        }

        // GET: api/Person/5
        [ResponseType(typeof(Person))]
        public IHttpActionResult Get(int id)
        {
            var person = _personRepository.Get(id);

            if (person != null)
            {
                return Ok(person);
            }
            return NotFound();
        }

        // POST: api/Person
        public IHttpActionResult Post(Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var createdPerson = _personRepository.Add(person);

            return CreatedAtRoute("DefaultApi", new { controller = "Person", id = createdPerson.Id }, createdPerson);
        }

        // PUT: api/Person/5
        public IHttpActionResult Put(int id, Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var existingPerson = _personRepository.Get(id);

            if (existingPerson == null) return NotFound();

            if (id != person.Id) return BadRequest();

            _personRepository.Update(person);

            return Ok();
        }

        // DELETE: api/Person/5
        public IHttpActionResult Delete(int id)
        {
            if (_personRepository.Get(id) == null) return NotFound();

            _personRepository.Delete(id);

            return Ok();
        }
    }
}
