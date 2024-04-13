using AutoMapper;
using Shop.API.CQRS.Commands.Product;
using Shop.API.CQRS.Commands.ProductCategory;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class ProducatCategoryProfile : Profile
    {
        public ProducatCategoryProfile()
        {
            CreateMap<ProductCategoryDTO, ProductCategory>();
            CreateMap<ProductCategory, ProductCategoryDTO>()
                .ForPath(d => d.Product, o => o.MapFrom(s => s.ProductNavigation))
                .ForPath(d => d.Category, o => o.MapFrom(s => s.CategoryNavigation));
            CreateMap<AddedProductCategoryCommand, ProductCategory>();
            CreateMap<EditedProductCommand, ProductCategory>();
        }
    }
}