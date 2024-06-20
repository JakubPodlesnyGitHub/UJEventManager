using AutoMapper;
using Azure.Core;
using MediatR;
using Shop.API.CQRS.Commands.Product;
using Shop.API.CQRS.Queries.Product;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;
using System.Reflection;

namespace Shop.API.CQRS.Handlers
{
    public class ProductHandler :
        IRequestHandler<GetProductsQuery, IList<ProductDTO>>,
        IRequestHandler<GetProductByIdQuery, ProductDTO>,
        IRequestHandler<GetSortedProductsQuery, IList<ProductDTO>>,
        IRequestHandler<AddedProductCommand, ProductDTO>,
        IRequestHandler<EditedProductCommand, ProductDTO>,
        IRequestHandler<DeletedProductCommand, ProductDTO>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<IList<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsWithProductAvailabilitesAndCategory();
            return _mapper.Map<IList<ProductDTO>>(products);
        }

        public async Task<ProductDTO> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdWithProductAvailabilitesAndCategory(request.Id);
            if (product is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Handle(AddedProductCommand request, CancellationToken cancellationToken)
        {
            var product = _productRepository.Insert(_mapper.Map<Product>(request));
            await _productRepository.Commit();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Handle(EditedProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            if (product is null)
            {
                throw new NotImplementedException();
            }

            product.Name = request.Name;
            product.CodeNumber = request.CodeNumber;
            product.SeriesNumber = request.SeriesNumber;
            product.ReleaseDate = request.ReleaseDate;
            if (request.Description is not null)
            {
                product.Description = request.Description;
            }
            if (request.Picture is not null)
            {
                product.Picture = request.Picture;
            }
            if (request.Rate is not null)
            {
                product.Rate = request.Rate;
            }

            _productRepository.Update(product);
            await _productRepository.Commit();
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<ProductDTO> Handle(DeletedProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);
            if (product is null)
            {
                throw new NotImplementedException();
            }
            await _productRepository.Delete(product.Id);
            await _productRepository.Commit();

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IList<ProductDTO>> Handle(GetSortedProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAll();

            var propertyInfo = typeof(Product).GetProperty(request.PropertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (propertyInfo == null)
            {
                throw new ArgumentException($"Property '{request.PropertyName}' does not exist on type 'Product'.");
            }

            var sortedProducts = request.Order.Equals("desc")
                ? products.OrderByDescending(x => propertyInfo.GetValue(x, null)).ToList()
                : products.OrderBy(x => propertyInfo.GetValue(x, null)).ToList();


            var filterProdcuts = FilterMinMaxProduct(request.Min, request.Max, sortedProducts);


            return _mapper.Map<IList<ProductDTO>>(filterProdcuts);
        }

        private IList<Product> FilterMinMaxProduct(double min, double max, IList<Product> products)
        {
            if (min != 0.0 && max != 0.0)
            {
                return products.Where(p => p.Rate >= min && p.Rate <= max).ToList();
            }

            if (min != 0.0)
            {
                return products.Where(p => p.Rate >= min).ToList();
            }
            if (max != 0.0)
            {
                return products.Where(p => p.Rate <= max).ToList();
            }
            return products;
        }
    }
}