using Shop.API.CQRS.Commands.Category;
using Shop.API.CQRS.Queries.Category;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class CategoryHandler :
        IQueryBaseHandler<GetCategoriesQuery, IList<CategoryDTO>>,
        IQueryBaseHandler<GetCategoryByIdQuery, IList<CategoryDTO>>,
        ICommandBaseHandler<AddedCategoryCommand, CategoryDTO>,
        ICommandBaseHandler<EditedCategoryCommand, CategoryDTO>,
        ICommandBaseHandler<DeletedCategoryCommand, CategoryDTO>
    {
        public Task<IList<CategoryDTO>> HandleAsync(GetCategoriesQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<IList<CategoryDTO>> HandleAsync(GetCategoryByIdQuery command)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> HandleAsync(EditedCategoryCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> HandleAsync(DeletedCategoryCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryDTO> HandleAsync(AddedCategoryCommand command)
        {
            throw new NotImplementedException();
        }
    }
}