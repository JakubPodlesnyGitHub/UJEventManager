using AutoMapper;
using Shop.API.CQRS.Commands.ProductCategory;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.ProductCategory;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class ProductCategoryHandler
        : IQueryBaseHandler<GetProductsCategoriesQuery, IList<ProductCategoryDTO>>,
          IQueryBaseHandler<GetProdcutCategoryByIdsQuery, ProductCategoryDTO>,
          ICommandBaseHandler<AddedProductCategoryCommand, ProductCategoryDTO>,
          ICommandBaseHandler<EditedProdcutCategoryCommand, ProductCategoryDTO>,
          ICommandBaseHandler<DeletedProductCategoryCommand, ProductCategoryDTO>
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryHandler(IMapper mapper, IProductCategoryRepository productCategoryRepository)
        {
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<IList<ProductCategoryDTO>> HandleAsync(GetProductsCategoriesQuery command)
        {
            return _mapper.Map<List<ProductCategoryDTO>>(await _productCategoryRepository.GetProductsCategoriesWithProductAndCategory());
        }

        public async Task<ProductCategoryDTO> HandleAsync(GetProdcutCategoryByIdsQuery command)
        {
            var searchProductCategory = await _productCategoryRepository.GetProductCategoryByIdsWithProductAndCategory(command.IdProduct, command.IdCategory);
            if (searchProductCategory is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<ProductCategoryDTO>(searchProductCategory);
        }

        public async Task<ProductCategoryDTO> HandleAsync(AddedProductCategoryCommand command)
        {
            var productCategory = _productCategoryRepository.Insert(_mapper.Map<ProductCategory>(command));
            await _productCategoryRepository.Commit();
            return _mapper.Map<ProductCategoryDTO>(productCategory);
        }

        public async Task<ProductCategoryDTO> HandleAsync(EditedProdcutCategoryCommand command)
        {
            var productCategory = await _productCategoryRepository.GetById(command.IdCategory, command.IdProduct);
            if (productCategory is null)
            {
                throw new NotImplementedException();
            }

            productCategory.IdProduct = command.IdProduct;
            productCategory.IdCategory = command.IdCategory;

            _productCategoryRepository.Update(productCategory);
            await _productCategoryRepository.Commit();
            return _mapper.Map<ProductCategoryDTO>(productCategory);
        }

        public async Task<ProductCategoryDTO> HandleAsync(DeletedProductCategoryCommand command)
        {
            var productCategory = await _productCategoryRepository.GetById(command.IdCategory, command.IdProduct);
            if (productCategory is null)
            {
                throw new NotImplementedException();
            }
            await _productCategoryRepository.Delete(command.IdProduct, command.IdCategory);
            await _productCategoryRepository.Commit();
            return _mapper.Map<ProductCategoryDTO>(productCategory);
        }
    }
}