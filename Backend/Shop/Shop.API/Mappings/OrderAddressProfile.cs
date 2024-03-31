using AutoMapper;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class OrderAddressProfile : Profile
    {
        private OrderAddressProfile()
        {
            CreateMap<OrderAddress, OrderAddressDTO>();
            CreateMap<OrderAddressDTO, OrderAddress>();
        }
    }
}