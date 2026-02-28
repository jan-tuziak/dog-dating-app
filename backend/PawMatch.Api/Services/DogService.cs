using Microsoft.EntityFrameworkCore;
using PawMatch.Api.Data;
using PawMatch.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PawMatch.Api.Services
{
    public class DogService : IDogService
    {
        private readonly PawMatchContext _context;

        public DogService(PawMatchContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DogDto>> GetAllAsync(int page = 1, int pageSize = 20)
        {
            return await _context.Dogs
                .AsNoTracking()
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(d => new DogDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Age = d.Age,
                    Breed = d.Breed
                })
                .ToListAsync();
        }

        public async Task<DogDto?> GetByIdAsync(int id)
        {
            var dog = await _context.Dogs.FindAsync(id);
            if (dog == null) return null;
            return new DogDto
            {
                Id = dog.Id,
                Name = dog.Name,
                Age = dog.Age,
                Breed = dog.Breed
            };
        }

        public async Task<DogDto> CreateAsync(CreateDogDto dto)
        {
            var entity = new Data.Dog
            {
                Name = dto.Name,
                Age = dto.Age,
                Breed = dto.Breed
            };
            _context.Dogs.Add(entity);
            await _context.SaveChangesAsync();
            return new DogDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Age = entity.Age,
                Breed = entity.Breed
            };
        }
    }
}
