using MediatR;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Commands.Product
{
    public class DeletedProductCommand : IRequest<ProductDTO>
    {
        public Guid Id { get; set; }

        public DeletedProductCommand(Guid id)
        {
            Id = id;
        }
    }
}