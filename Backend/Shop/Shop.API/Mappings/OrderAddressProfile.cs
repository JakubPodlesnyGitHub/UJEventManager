using AutoMapper;
using Shop.API.CQRS.Commands.OrderAddress;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class OrderAddressProfile : Profile
    {
        public OrderAddressProfile()
        {
            CreateMap<OrderAddress, OrderAddressDTO>();
            CreateMap<OrderAddressDTO, OrderAddress>();
            CreateMap<AddedOrderAddressCommand, OrderAddress>();
            CreateMap<EditedOrderAddressCommand, OrderAddress>();
        }
    }
}