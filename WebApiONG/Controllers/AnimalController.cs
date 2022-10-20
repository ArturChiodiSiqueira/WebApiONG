using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using WebApiONG.Models;
using WebApiONG.Services;

namespace WebApiONG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalServices _animalService;

        public AnimalController(AnimalServices animalService)
        {
            _animalService = animalService;
        }

        [HttpGet]
        public ActionResult<List<Animal>> Get() => _animalService.Get();
        [HttpGet("{chip:length(24)}", Name = "GetAnimal")]
        public ActionResult<Animal> Get(string chip)
        {
            var animal = _animalService.Get(chip);

            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        [HttpPost]
        public ActionResult<Animal> Create(Animal animal)
        {
            _animalService.Create(animal);
            return CreatedAtRoute("GetAnimal", new { chip = animal.Chip.ToString() }, animal);
        }

        [HttpPut]
        public ActionResult<Animal> Update(Animal animalIn, string chip)
        {
            var animal = _animalService.Get(chip);

            if (animal == null)
                return NotFound();

            _animalService.Update(chip, animalIn);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(string chip)
        {
            var animal = _animalService.Get(chip);

            if (animal == null)
                return NotFound();

            _animalService.Remove(animal);

            return NoContent();
        }
    }
}
