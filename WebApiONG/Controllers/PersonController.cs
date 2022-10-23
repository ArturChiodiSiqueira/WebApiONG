using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApiONG.Models;
using WebApiONG.Services;

namespace WebApiONG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonServices _personService;

        public PersonController(PersonServices personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public ActionResult<List<Person>> Get() => _personService.Get();
        [HttpGet("{cpf:length(24)}", Name = "GetPerson")]
        public ActionResult<Person> Get(string cpf)
        {
            var person = _personService.Get(cpf);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public ActionResult<Person> Create(Person person)
        {
            _personService.Create(person);
            return CreatedAtRoute("GetPerson", new { cpf = person.Cpf.ToString() }, person);
        }

        [HttpPut]
        public ActionResult<Person> Update(Person personIn, string cpf)
        {
            var person = _personService.Get(cpf);

            if (person == null)
                return NotFound();

            _personService.Update(cpf, personIn);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(string cpf)
        {
            var person = _personService.Get(cpf);

            if (person == null)
                return NotFound();

            _personService.Remove(person);

            return NoContent();
        }
    }
}
