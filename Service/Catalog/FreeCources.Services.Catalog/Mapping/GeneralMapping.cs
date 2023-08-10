using AutoMapper;
using FreeCources.Services.Catalog.Dtos;
using FreeCources.Services.Catalog.Models;

namespace FreeCources.Services.Catalog.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            CreateMap<Cource, CourceDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Feature, FeatureDto>().ReverseMap();
            CreateMap<Cource ,CourceCreateDto>().ReverseMap();
            CreateMap<Cource, CourceUpdateDto>().ReverseMap();
        }
    }
}
