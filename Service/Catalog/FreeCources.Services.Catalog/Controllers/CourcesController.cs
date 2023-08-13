using FreeCource.Shared.ControllerBases;
using FreeCources.Services.Catalog.Dtos;
using FreeCources.Services.Catalog.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreeCources.Services.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal class CourcesController : CustomBaseController
    {
        private readonly ICourceService _courceService;

        internal CourcesController(ICourceService courceService)
        {
            _courceService = courceService;
        }

        public async Task<IActionResult> GetAll()
        {
            var response = await _courceService.GetAllAsync();
            return CreateActionResultInstance(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await _courceService.GetByIdAsync(id);
            return CreateActionResultInstance(response);
        }

        [Route("/api/[controller]/GetAllByUserId/{userId}")]
        
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var response = await _courceService.GetAllByUserIdAsync(userId);
            return CreateActionResultInstance(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CourceCreateDto courceCreateDto)
        {
            var response = await _courceService.CreateAsync(courceCreateDto);
            return CreateActionResultInstance(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(CourceUpdateDto courceUpdateDto)
        {
            var response = await _courceService.UpdateAsync(courceUpdateDto);
            return CreateActionResultInstance(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var response = await _courceService.DeleteAsync(id);
            return CreateActionResultInstance(response);
        }
    }
}
