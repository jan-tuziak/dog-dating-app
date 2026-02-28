using Microsoft.AspNetCore.Mvc;
using PawMatch.Api.Models;
using PawMatch.Api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PawMatch.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DogsController : ControllerBase
    {
        private readonly IDogService _dogService;

        public DogsController(IDogService dogService)
        {
            _dogService = dogService;
        }

        [HttpGet]
        public async Task<IEnumerable<DogDto>> Get(int page = 1, int pageSize = 20)
        {
            return await _dogService.GetAllAsync(page, pageSize);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DogDto>> GetById(int id)
        {
            var dog = await _dogService.GetByIdAsync(id);
            if (dog == null) return NotFound();
            return dog;
        }

        [HttpPost]
        public async Task<ActionResult<DogDto>> Create(CreateDogDto dto)
        {
            var created = await _dogService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
    }
}
