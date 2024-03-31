using Shop.API.CQRS.Commands.Product;
using Shop.API.CQRS.Queries.Product;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class ProductHandler :
        IQueryBaseHandler<GetProducts, IList<ProductDTO>>,
        IQueryBaseHandler<GetProductByIdQuery, ProductDTO>,
        ICommandBaseHandler<AddedProductCommand, ProductDTO>,
        ICommandBaseHandler<EditedProductCommand, ProductDTO>,
        ICommandBaseHandler<DeletedProductCommand, ProductDTO>
    {
        public Task<IList<ProductDTO>> HandleAsync(GetProducts command)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> HandleAsync(GetProductByIdQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> HandleAsync(AddedProductCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> HandleAsync(EditedProductCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDTO> HandleAsync(DeletedProductCommand command)
        {
            throw new NotImplementedException();
        }
    }
}