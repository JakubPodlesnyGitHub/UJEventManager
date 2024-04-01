using AutoMapper;
using Shop.API.CQRS.Commands.Product;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.Product;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class ProductHandler :
        IQueryBaseHandler<GetProductsQuery, IList<ProductDTO>>,
        IQueryBaseHandler<GetProductByIdQuery, ProductDTO>,
        ICommandBaseHandler<AddedProductCommand, ProductDTO>,
        ICommandBaseHandler<EditedProductCommand, ProductDTO>,
        ICommandBaseHandler<DeletedProductCommand, ProductDTO>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IList<ProductDTO>> HandleAsync(GetProductsQuery command)
        {
            var products = await _productRepository.GetAll();
            return _mapper.Map<IList<ProductDTO>>(products);
        }

        public async Task<ProductDTO> HandleAsync(GetProductByIdQuery command)
        {
            var product = await _productRepository.GetById(command.Id);
            if (product is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> HandleAsync(AddedProductCommand command)
        {
            var product = _productRepository.Insert(_mapper.Map<Product>(command));
            await _productRepository.Commit();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> HandleAsync(EditedProductCommand command)
        {
            var product = await _productRepository.GetById(command.Id);
            if (product is null)
            {
                throw new NotImplementedException();
            }

            product.Name = command.Name;
            product.Category = command.Category;
            product.CodeNumber = command.CodeNumber;
            product.SeriesNumber = command.SeriesNumber;
            product.ReleaseDate = command.ReleaseDate;
            if (command.Description is not null)
            {
                product.Description = command.Description;
            }
            if (command.Picture is not null)
            {
                product.Picture = command.Picture;
            }
            if (command.Rate is not null)
            {
                product.Rate = command.Rate;
            }

            _productRepository.Update(product);
            await _productRepository.Commit();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> HandleAsync(DeletedProductCommand command)
        {
            var product = await _productRepository.GetById(command.Id);
            if (product is null)
            {
                throw new NotImplementedException();
            }
            await _productRepository.Delete(product);
            await _productRepository.Commit();

            return _mapper.Map<ProductDTO>(product);
        }
    }
}