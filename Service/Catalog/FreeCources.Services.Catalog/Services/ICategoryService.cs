using FreeCource.Shared.Dtos;
using FreeCources.Services.Catalog.Dtos;
using FreeCources.Services.Catalog.Models;

namespace FreeCources.Services.Catalog.Services
{
    interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();

        Task<Response<CategoryDto>> CreateAsync(Category category);

        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
