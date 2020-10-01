using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnimalSpawn.Domain.DTOs;
using AnimalSpawn.Domain.Entities;
using AnimalSpawn.Domain.Interfaces;
using AnimalSpawn.Infraestructure.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace AnimalSpawn.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalRepository animalRepository;
        private readonly IMapper mapper;
        public AnimalController(IAnimalRepository repository, IMapper _mapper)
        {
            animalRepository = repository;
            mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var animals = await animalRepository.GetAnimals();
            var animalsDto = mapper.Map<IEnumerable<Animal>, IEnumerable<AnimalResponseDto>>(animals);
            return Ok(animalsDto);

        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var animal = await animalRepository.GetAnimal(id);
            var animalDto = mapper.Map<Animal, AnimalResponseDto>(animal);
            return Ok(animalDto);

        }

        [HttpPost]
        public async Task<IActionResult> Post(Animal animal)
        {
            await animalRepository.AddAnimal(animal);
            return Ok(animal);
        }

        public async Task<IActionResult> Get(int id)
        {
            var animals = await animalRepository.GetAnimals();
            var animalsDto = animals.Select(animal => new AnimalResponseDto
            {
                CaptureCondition = animal.CaptureCondition,
                CaptureDate = animal.CaptureDate ?? DateAndTime.Now,
                Description = animal.Description,
                EstimatedAge = animal.EstimatedAge ?? 0,
                FamilyId = animal.FamilyId,
                GenusId = animal.GenusId,
                Id = animal.Id,
                Gender = animal.Gender ?? false,
                Height = animal.Height ?? 0,
                Name = animal.Name,
                SpeciesId = animal.SpeciesId,
                Weight = animal.Weight ?? 0
            });
            return Ok(animalsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AnimalRequestDto animalDto)
        {
            var animal = mapper.Map<AnimalRequestDto, Animal>(animalDto);
            await animalRepository.AddAnimal(animal);
            var animalresponseDto = mapper.Map<Animal, AnimalResponseDto>(animal);
            return Ok(animalresponseDto);
        }
    }
}
