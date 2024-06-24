using AutoMapper;
using MediatR;
using Shop.API.CQRS.Commands.PorductAvailability;
using Shop.API.CQRS.Queries.PorductAvailability;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class ProductAvailabilityHandler :
        IRequestHandler<GetProductAvailabilitiesQuery, IList<ProductAvailabilityDTO>>,
        IRequestHandler<GetProductAvailabilityByIdQuery, ProductAvailabilityDTO>,
        IRequestHandler<AddedProductAvailabilityCommand, ProductAvailabilityDTO>,
        IRequestHandler<EditedProductAvailabilityCommand, ProductAvailabilityDTO>,
        IRequestHandler<DeletedProductAvailabilityCommand, ProductAvailabilityDTO>
    {
        private readonly IMapper _mapper;
        private readonly IProductAvailabilityRepository _productAvailabilityRepository;

        public ProductAvailabilityHandler(IMapper mapper, IProductAvailabilityRepository productAvailabilityRepository)
        {
            _mapper = mapper;
            _productAvailabilityRepository = productAvailabilityRepository;
        }

        public async Task<IList<ProductAvailabilityDTO>> Handle(GetProductAvailabilitiesQuery request, CancellationToken cancellationToken)
        {
            var productAvailabilities = await _productAvailabilityRepository.GetProductsAvailabilitiesWithProducts();
            return _mapper.Map<IList<ProductAvailabilityDTO>>(productAvailabilities);
        }

        public async Task<ProductAvailabilityDTO> Handle(GetProductAvailabilityByIdQuery request, CancellationToken cancellationToken)
        {
            var productAvailability = await _productAvailabilityRepository.GetProductAvailabilityByIdWithProduct(request.Id);
            if (productAvailability is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<ProductAvailabilityDTO>(productAvailability);
        }

        public async Task<ProductAvailabilityDTO> Handle(AddedProductAvailabilityCommand request, CancellationToken cancellationToken)
        {
            var productAvailability = _productAvailabilityRepository.Insert(_mapper.Map<ProductAvailability>(request));
            await _productAvailabilityRepository.Commit();
            return _mapper.Map<ProductAvailabilityDTO>(productAvailability);
        }

        public async Task<ProductAvailabilityDTO> Handle(EditedProductAvailabilityCommand request, CancellationToken cancellationToken)
        {
            var productAvailability = await _productAvailabilityRepository.GetProductAvailabilityByProductIdWithProduct(request.IdProduct);
            if (productAvailability is null)
            {
                throw new NotImplementedException();
            }

            productAvailability.Availability = request.Availability;

            _productAvailabilityRepository.Update(productAvailability);
            await _productAvailabilityRepository.Commit();
            return _mapper.Map<ProductAvailabilityDTO>(productAvailability);
        }

        public async Task<ProductAvailabilityDTO> Handle(DeletedProductAvailabilityCommand request, CancellationToken cancellationToken)
        {
            var productAvailability = await _productAvailabilityRepository.GetById(request.Id);
            if (productAvailability is null)
            {
                throw new NotImplementedException();
            }
            await _productAvailabilityRepository.Delete(productAvailability.Id);
            await _productAvailabilityRepository.Commit();

            return _mapper.Map<ProductAvailabilityDTO>(productAvailability);
        }
    }
}