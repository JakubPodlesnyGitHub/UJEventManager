using Shop.API.CQRS.Commands.PorductAvailability;
using Shop.API.CQRS.Queries.PorductAvailability;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class ProductAvailabilityHandler :
        IQueryBaseHandler<GetProductAvailabilitiesQuery, IList<ProductAvailabilityDTO>>,
        IQueryBaseHandler<GetProductAvailabilityByIdQuery, ProductAvailabilityDTO>,
        ICommandBaseHandler<AddedProductAvailabilityCommand, ProductAvailabilityDTO>,
        ICommandBaseHandler<EditedProductAvailabilityCommand, ProductAvailabilityDTO>,
        ICommandBaseHandler<DeletedProductAvailabilityCommand, ProductAvailabilityDTO>
    {
        public Task<IList<ProductAvailabilityDTO>> HandleAsync(GetProductAvailabilitiesQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<ProductAvailabilityDTO> HandleAsync(GetProductAvailabilityByIdQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<ProductAvailabilityDTO> HandleAsync(AddedProductAvailabilityCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ProductAvailabilityDTO> HandleAsync(EditedProductAvailabilityCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ProductAvailabilityDTO> HandleAsync(DeletedProductAvailabilityCommand command)
        {
            throw new NotImplementedException();
        }
    }
}