using AutoMapper;
using MediatR;
using Shop.API.CQRS.Commands.ProductCategory;
using Shop.API.CQRS.Queries.ProductCategory;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class ProductCategoryHandler
        : IRequestHandler<GetProductsCategoriesQuery, IList<ProductCategoryDTO>>,
          IRequestHandler<GetProdcutCategoryByIdsQuery, ProductCategoryDTO>,
          IRequestHandler<AddedProductCategoryCommand, ProductCategoryDTO>,
          IRequestHandler<EditedProdcutCategoryCommand, ProductCategoryDTO>,
          IRequestHandler<DeletedProductCategoryCommand, ProductCategoryDTO>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryHandler(IMapper mapper, IProductCategoryRepository productCategoryRepository)
        {
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<IList<ProductCategoryDTO>> Handle(GetProductsCategoriesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<ProductCategoryDTO>>(await _productCategoryRepository.GetProductsCategoriesWithProductAndCategory());
        }

        public async Task<ProductCategoryDTO> Handle(GetProdcutCategoryByIdsQuery request, CancellationToken cancellationToken)
        {
            var searchProductCategory = await _productCategoryRepository.GetProductCategoryByIdsWithProductAndCategory(request.IdProduct, request.IdCategory);
            if (searchProductCategory is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<ProductCategoryDTO>(searchProductCategory);
        }

        public async Task<ProductCategoryDTO> Handle(AddedProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = _productCategoryRepository.Insert(_mapper.Map<ProductCategory>(request));
            await _productCategoryRepository.Commit();
            return _mapper.Map<ProductCategoryDTO>(productCategory);
        }

        public async Task<ProductCategoryDTO> Handle(EditedProdcutCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.GetById(request.IdCategory, request.IdProduct);
            if (productCategory is null)
            {
                throw new NotImplementedException();
            }

            productCategory.IdProduct = request.IdProduct;
            productCategory.IdCategory = request.IdCategory;

            _productCategoryRepository.Update(productCategory);
            await _productCategoryRepository.Commit();
            return _mapper.Map<ProductCategoryDTO>(productCategory);
        }

        public async Task<ProductCategoryDTO> Handle(DeletedProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var productCategory = await _productCategoryRepository.GetById(request.IdCategory, request.IdProduct);
            if (productCategory is null)
            {
                throw new NotImplementedException();
            }
            await _productCategoryRepository.Delete(request.IdProduct, request.IdCategory);
            await _productCategoryRepository.Commit();
            return _mapper.Map<ProductCategoryDTO>(productCategory);
        }
    }
}