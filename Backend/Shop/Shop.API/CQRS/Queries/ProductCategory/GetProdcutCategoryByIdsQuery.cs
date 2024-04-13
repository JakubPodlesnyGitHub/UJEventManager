using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.ProductCategory
{
    public class GetProdcutCategoryByIdsQuery : IRequest<ProductCategoryDTO>
    {
        public Guid IdCategory { get; set; }
        public Guid IdProduct { get; set; }

        public GetProdcutCategoryByIdsQuery(Guid idCategory, Guid idProduct)
        {
            IdCategory = idCategory;
            IdProduct = idProduct;
        }
    }
}