using PawMatch.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PawMatch.Api.Services
{
    public interface IDogService
    {
        Task<IEnumerable<DogDto>> GetAllAsync(int page = 1, int pageSize = 20);
        Task<DogDto?> GetByIdAsync(int id);
        Task<DogDto> CreateAsync(CreateDogDto dto);
    }
}
