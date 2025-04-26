using Application.Features.Category.Commands;
using Application.Features.Category.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Profiles;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<Category, CategoryDto>();
        CreateMap<CreateCategoryCommand, Category>();
        CreateMap<DeleteCategoryCommand, Category>();
        CreateMap<RestoreCategoryCommand, Category>();
        CreateMap<UpdateCategoryCommand, Category>();
    }
}
