using Shop.API.CQRS.Commands.OrderAddress;
using Shop.API.CQRS.Queries.OrderAddress;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class OrderAddressHandler :
        IQueryBaseHandler<GetOrderAdderssesQuery, IList<OrderAddressDTO>>,
        IQueryBaseHandler<GetOrderAddressByIdQuery, OrderAddressDTO>,
        ICommandBaseHandler<AddedOrderAddressCommand, OrderAddressDTO>,
        ICommandBaseHandler<EditedOrderAddressCommand, OrderAddressDTO>,
        ICommandBaseHandler<DeletedOrderAddressCommand, OrderAddressDTO>
    {
        public Task<IList<OrderAddressDTO>> HandleAsync(GetOrderAdderssesQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<OrderAddressDTO> HandleAsync(GetOrderAddressByIdQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<OrderAddressDTO> HandleAsync(AddedOrderAddressCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<OrderAddressDTO> HandleAsync(EditedOrderAddressCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<OrderAddressDTO> HandleAsync(DeletedOrderAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}