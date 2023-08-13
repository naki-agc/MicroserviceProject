using AutoMapper;
using FreeCource.Shared.Dtos;
using FreeCources.Services.Catalog.Dtos;
using FreeCources.Services.Catalog.Models;
using FreeCources.Services.Catalog.Settings;
using MongoDB.Driver;

namespace FreeCources.Services.Catalog.Services
{
    public class CourceService:ICourceService
    {
        private readonly IMongoCollection<Cource> _courceCollection;
        private readonly IMongoCollection<Category> _categoryCollection;

        private readonly IMapper _mapper;

        public CourceService(IMapper mapper, IDatabaseSettings databaseSettings)
        {

            var client = new MongoClient(databaseSettings.ConnectionString);//cliente bağlandık

            var database = client.GetDatabase(databaseSettings.DatabaseName);//client veritabanı ismine bağlandık

            _courceCollection = database.GetCollection<Cource>(databaseSettings.CatagoryCollectionName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CatagoryCollectionName);

            _mapper = mapper;
            _mapper = mapper;
        }

        public async Task<Response<List<CourceDto>>> GetAllAsync()
        {
            var cources = await _courceCollection.Find(cource => true).ToListAsync();

            if (cources.Any())//içinde kayıt var ise...
            {
                foreach (var cource in cources)
                {
                    cource.Category = await _categoryCollection.Find<Category>(x => x.Id == cource.CategoryId).FirstAsync();
                }
            }
            else
            {
                cources = new List<Cource>();
            }

            return Response<List<CourceDto>>.Success(_mapper.Map<List<CourceDto>>(cources), 200);
        }

        public async Task<Response<CourceDto>>  GetByIdAsync(string id)
        {
            var cource = await _courceCollection.Find<Cource>(x => x.Id == id).FirstOrDefaultAsync();

            if (cource == null)
            {
                return Response<CourceDto>.Fail("Cource not found", 404);
            }

            cource.Category = await _categoryCollection.Find<Category>(y=> y.Id == cource.CategoryId).FirstAsync();

            return Response<CourceDto>.Success(_mapper.Map<CourceDto>(cource),200);
        }

        public async Task<Response<List<CourceDto>>> GetAllByUserIdAsync(string userId)
        {
            var cources = await _courceCollection.Find<Cource>(x => x.UserId == userId).ToListAsync();

            if (cources.Any())//içinde kayıt var ise...
            {
                foreach (var cource in cources)
                {
                    cource.Category = await _categoryCollection.Find<Category>(x => x.Id == cource.CategoryId).FirstAsync();
                }
            }
            else
            {
                cources = new List<Cource>();
            }

            return Response<List<CourceDto>>.Success(_mapper.Map<List<CourceDto>>(cources), 200);

        }

        public async Task<Response<List<CourceDto>>> CreateAsync(CourceCreateDto courceCreateDto)
        {
            var newCource = _mapper.Map<Cource>(courceCreateDto);
            newCource.CreatedTime = DateTime.Now;
             
            await _courceCollection.InsertOneAsync(newCource);//ef coredeki gibi bu InsertOneAsync ID sinide ekledi!!!

            return Response<List<CourceDto>>.Success(_mapper.Map<List<CourceDto>>(newCource), 200);
        }


        public async Task<Response<NoContent>> UpdateAsync(CourceUpdateDto courceUpdateDto)
        {
            var updateCource = _mapper.Map<Cource>(courceUpdateDto);
            var result = _courceCollection.FindOneAndReplace(x => x.Id == courceUpdateDto.Id, updateCource);

            if (result == null)
            {
                return Response<NoContent>.Fail("Cource not found", 404);
            }

            return Response<NoContent>.Success(204);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = _courceCollection.DeleteOneAsync(x => x.Id == id);
             
            if (result != null)  // burada DeletedCount olacak ama çıkmadı ??? bi bakarsın 
            {
                return Response<NoContent>.Success(204);
            }

            return Response<NoContent>.Fail("Cource not found" , 204);
        }
    }
}
