using AutoMapper;
using Shop.API.CQRS.Commands.Product;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<AddedProductCommand, Product>();
            CreateMap<EditedProductCommand, Product>();
        }
    }
}