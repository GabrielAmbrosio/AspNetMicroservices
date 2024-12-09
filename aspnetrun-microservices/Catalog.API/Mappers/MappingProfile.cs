using AutoMapper;
using Catalog.API.Dtos;
using Catalog.API.Entities;

namespace Catalog.API.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                       .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
                       .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary))
                       .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                       .ForMember(dest => dest.ImageFile, opt => opt.MapFrom(src => src.ImageFile))
                       .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));
        }
    }
}
