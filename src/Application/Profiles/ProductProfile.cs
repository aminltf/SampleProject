using Application.Features.Product.Commands;
using Application.Features.Product.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Product, ProductDto>();
        CreateMap<CreateProductCommand, Product>();
        CreateMap<DeleteProductCommand, Product>();
        CreateMap<RestoreProductCommand, Product>();
        CreateMap<UpdateProductCommand, Product>();
    }
}
