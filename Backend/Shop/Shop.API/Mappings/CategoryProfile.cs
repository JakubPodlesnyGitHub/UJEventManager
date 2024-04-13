using AutoMapper;
using Shop.API.CQRS.Commands.Category;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDTO>()
                .ForPath(d => d.Products, o => o.MapFrom(s => s.ProductCategoriesNavigation.Select(x => x.ProductNavigation)));
            CreateMap<CategoryDTO, Category>();
            CreateMap<AddedCategoryCommand, Category>();
            CreateMap<EditedCategoryCommand, Category>();
        }
    }
}