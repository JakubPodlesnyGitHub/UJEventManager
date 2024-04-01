using AutoMapper;
using Shop.API.CQRS.Commands.Category;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.Category;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class CategoryHandler :
        IQueryBaseHandler<GetCategoriesQuery, IList<CategoryDTO>>,
        IQueryBaseHandler<GetCategoryByIdQuery, CategoryDTO>,
        ICommandBaseHandler<AddedCategoryCommand, CategoryDTO>,
        ICommandBaseHandler<EditedCategoryCommand, CategoryDTO>,
        ICommandBaseHandler<DeletedCategoryCommand, CategoryDTO>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IList<CategoryDTO>> HandleAsync(GetCategoriesQuery command)
        {
            return _mapper.Map<IList<CategoryDTO>>(await _categoryRepository.GetAll());
        }

        public async Task<CategoryDTO> HandleAsync(GetCategoryByIdQuery command)
        {
            var searchChategory = await _categoryRepository.GetById(command.Id);
            if (searchChategory is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<CategoryDTO>(searchChategory);
        }

        public async Task<CategoryDTO> HandleAsync(EditedCategoryCommand command)
        {
            var category = await _categoryRepository.GetById(command.Id);
            if (category is null)
            {
                throw new NotImplementedException();
            }
            category.Name = command.Name;
            _categoryRepository.Update(category);
            await _categoryRepository.Commit();
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> HandleAsync(DeletedCategoryCommand command)
        {
            var category = await _categoryRepository.GetById(command.Id);
            if (category is null)
            {
                throw new NotImplementedException();
            }
            await _categoryRepository.Delete(category);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> HandleAsync(AddedCategoryCommand command)
        {
            var category = _categoryRepository.Insert(_mapper.Map<Category>(command));
            await _categoryRepository.Commit();
            return _mapper.Map<CategoryDTO>(category);
        }
    }
}