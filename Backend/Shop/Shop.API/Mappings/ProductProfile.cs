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
            CreateMap<Product, ProductDTO>()
                .ForPath(d => d.ProductAvailabilities, o => o.MapFrom(s => s.ProductAvailabilitiesNavigation));
            CreateMap<ProductDTO, Product>();
            CreateMap<AddedProductCommand, Product>();
            CreateMap<EditedProductCommand, Product>();
        }
    }
}