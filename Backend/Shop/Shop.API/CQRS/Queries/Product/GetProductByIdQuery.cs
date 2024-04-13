using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Queries.Product
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public Guid Id { get; set; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}