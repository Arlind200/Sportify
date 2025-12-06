using AutoMapper;
using Catalog.Application.Commands;
using Catalog.Application.Responses;
using Catalog.CORE.Entities;

namespace Catalog.Application.Mappers;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductMapper, ProductResponse>().ReverseMap();
        CreateMap<ProductBrand, BrandResponse>().ReverseMap();
        CreateMap<ProductType, TypeResponse>().ReverseMap();
        CreateMap<Product, CreateProductCommand>().ReverseMap();
    }


}
