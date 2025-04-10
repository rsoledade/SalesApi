using AutoMapper;
using SalesApi.Application.DTO;
using SalesApi.Domain.Entities;

namespace SalesApi.Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<SaleItem, SaleItemDto>().ReverseMap();
            CreateMap<Sale, SaleDto>()
                .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.GetTotalAmount()))
                .ReverseMap();
        }
    }
}
