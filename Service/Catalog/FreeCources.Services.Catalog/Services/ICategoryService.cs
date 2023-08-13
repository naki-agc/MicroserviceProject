using FreeCource.Shared.Dtos;
using FreeCources.Services.Catalog.Dtos;
using FreeCources.Services.Catalog.Models;

namespace FreeCources.Services.Catalog.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();

        Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto);

        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
