using AutoMapper;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class ProductAvailabilityProfile : Profile
    {
        public ProductAvailabilityProfile()
        {
            CreateMap<ProductAvailability, ProductAvailabilityDTO>();
            CreateMap<ProductAvailabilityDTO, ProductAvailability>();
        }
    }
}