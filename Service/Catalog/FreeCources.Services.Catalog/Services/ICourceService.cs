using FreeCource.Shared.Dtos;
using FreeCources.Services.Catalog.Dtos;

namespace FreeCources.Services.Catalog.Services
{
    public interface ICourceService
    {

        Task<Response<List<CourceDto>>> GetAllAsync();

        Task<Response<CourceDto>> GetByIdAsync(string id);

        Task<Response<List<CourceDto>>> GetAllByUserIdAsync(string userId);

        Task<Response<List<CourceDto>>> CreateAsync(CourceCreateDto courceCreateDto);

        Task<Response<NoContent>> UpdateAsync(CourceUpdateDto courceUpdateDto);
        Task<Response<NoContent>> DeleteAsync(string id);




    }
}
