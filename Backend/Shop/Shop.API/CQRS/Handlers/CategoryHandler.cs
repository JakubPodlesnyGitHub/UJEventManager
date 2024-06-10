using AutoMapper;
using MediatR;
using Shop.API.CQRS.Commands.Category;
using Shop.API.CQRS.Queries.Category;
using Shop.Domain.Domain;
using Shop.Infrastructure.Repositories.Interfaces;
using Shop.Shared.Dtos.Response;

namespace Shop.API.CQRS.Handlers
{
    public class CategoryHandler :
        IRequestHandler<GetCategoriesQuery, IList<CategoryDTO>>,
        IRequestHandler<GetCategoryByIdQuery, CategoryDTO>,
        IRequestHandler<AddedCategoryCommand, CategoryDTO>,
        IRequestHandler<EditedCategoryCommand, CategoryDTO>,
        IRequestHandler<DeletedCategoryCommand, CategoryDTO>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IList<CategoryDTO>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IList<CategoryDTO>>(await _categoryRepository.GetCategoriesWithProducts());
        }

        public async Task<CategoryDTO> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var searchChategory = await _categoryRepository.GetCategoryByIdWithProducts(request.Id);
            if (searchChategory is null)
            {
                throw new NotImplementedException();
            }
            return _mapper.Map<CategoryDTO>(searchChategory);
        }

        public async Task<CategoryDTO> Handle(AddedCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _categoryRepository.Insert(_mapper.Map<Category>(request));
            await _categoryRepository.Commit();
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> Handle(EditedCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.Id) ?? throw new NotImplementedException();
            category.Name = request.Name;
            _categoryRepository.Update(category);
            await _categoryRepository.Commit();
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<CategoryDTO> Handle(DeletedCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetById(request.Id);
            if (category is null)
            {
                throw new NotImplementedException();
            }
            await _categoryRepository.Delete(category.Id);
            return _mapper.Map<CategoryDTO>(category);
        }
    }
}