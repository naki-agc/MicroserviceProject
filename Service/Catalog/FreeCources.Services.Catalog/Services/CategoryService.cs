using Amazon.Runtime.Internal.Util;
using AutoMapper;
using FreeCource.Shared.Dtos;
using FreeCources.Services.Catalog.Dtos;
using FreeCources.Services.Catalog.Models;
using FreeCources.Services.Catalog.Settings;
using Microsoft.AspNetCore.DataProtection.Repositories;
using MongoDB.Driver;

namespace FreeCources.Services.Catalog.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;

        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {

            var client = new MongoClient(databaseSettings.ConnectionString);//cliente bağlandık

            var database = client.GetDatabase(databaseSettings.DatabaseName);//client veritabanı ismine bağlandık

            _categoryCollection = database.GetCollection<Category>(databaseSettings.CatagoryCollectionName);
            
            _mapper = mapper;

        }

        
        public async Task<Response<List<CategoryDto>>> GetAllAsync()
        {
            var categotries = await _categoryCollection.Find(category => true).ToListAsync();

            return Response<List<CategoryDto>>.Success(_mapper.Map<List<CategoryDto>>(categotries), 200);
           
        }


        public async Task<Response<CategoryDto>> CreateAsync(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _categoryCollection.InsertOneAsync(category);

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category),200);
        }


        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            if (category == null)
            {
                return Response<CategoryDto>.Fail("Category not found", 404);
            }

            return Response<CategoryDto>.Success(_mapper.Map<CategoryDto>(category), 200);
        }


    }
}
