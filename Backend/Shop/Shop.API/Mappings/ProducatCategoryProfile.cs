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
            CreateMap<ProductCategory, ProductCategoryDTO>();
            CreateMap<AddedProductCategoryCommand, ProductCategory>();
            CreateMap<EditedProductCommand, ProductCategory>();
        }
    }
}