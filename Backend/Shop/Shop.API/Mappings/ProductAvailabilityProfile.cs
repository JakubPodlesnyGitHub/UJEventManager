using AutoMapper;
using Shop.API.CQRS.Commands.PorductAvailability;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class ProductAvailabilityProfile : Profile
    {
        public ProductAvailabilityProfile()
        {
            CreateMap<ProductAvailability, ProductAvailabilityDTO>()
                .ForPath(d => d.Product, o => o.MapFrom(s => s.ProductNavigation));
            CreateMap<ProductAvailabilityDTO, ProductAvailability>();
            CreateMap<AddedProductAvailabilityCommand, ProductAvailability>();
            CreateMap<EditedProductAvailabilityCommand, ProductAvailability>();
        }
    }
}