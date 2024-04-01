using AutoMapper;
using Shop.API.CQRS.Commands.PorductAvailability;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.PorductAvailability;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
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
        private readonly IMapper _mapper;
        private readonly IProductAvailabilityRepository _productAvailabilityRepository;

        public ProductAvailabilityHandler(IMapper mapper, IProductAvailabilityRepository productAvailabilityRepository)
        {
            _mapper = mapper;
            _productAvailabilityRepository = productAvailabilityRepository;
        }

        public async Task<IList<ProductAvailabilityDTO>> HandleAsync(GetProductAvailabilitiesQuery command)
        {
            var productAvailabilities = await _productAvailabilityRepository.GetAll();
            return _mapper.Map<IList<ProductAvailabilityDTO>>(productAvailabilities);
        }

        public async Task<ProductAvailabilityDTO> HandleAsync(GetProductAvailabilityByIdQuery command)
        {
            var productAvailability = await _productAvailabilityRepository.GetById(command.Id);
            if (productAvailability is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<ProductAvailabilityDTO>(productAvailability);
        }

        public async Task<ProductAvailabilityDTO> HandleAsync(AddedProductAvailabilityCommand command)
        {
            var productAvailability = _productAvailabilityRepository.Insert(_mapper.Map<ProductAvailability>(command));
            await _productAvailabilityRepository.Commit();
            return _mapper.Map<ProductAvailabilityDTO>(productAvailability);
        }

        public async Task<ProductAvailabilityDTO> HandleAsync(EditedProductAvailabilityCommand command)
        {
            var productAvailability = await _productAvailabilityRepository.GetById(command.Id);
            if (productAvailability is null)
            {
                throw new NotImplementedException();
            }

            productAvailability.Availability = command.Availability;
            productAvailability.Status = command.Status;
            productAvailability.IdProduct = command.IdProduct;

            _productAvailabilityRepository.Update(productAvailability);
            await _productAvailabilityRepository.Commit();
            return _mapper.Map<ProductAvailabilityDTO>(productAvailability);
        }

        public async Task<ProductAvailabilityDTO> HandleAsync(DeletedProductAvailabilityCommand command)
        {
            var productAvailability = await _productAvailabilityRepository.GetById(command.Id);
            if (productAvailability is null)
            {
                throw new NotImplementedException();
            }
            await _productAvailabilityRepository.Delete(productAvailability);
            await _productAvailabilityRepository.Commit();

            return _mapper.Map<ProductAvailabilityDTO>(productAvailability);
        }
    }
}