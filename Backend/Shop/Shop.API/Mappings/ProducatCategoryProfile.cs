using AutoMapper;
using Shop.Domain.Domain;
using Shop.Shared.Dtos.Response;

namespace Shop.API.Mappings
{
    public class ProducatCategoryProfile : Profile
    {
        public ProducatCategoryProfile()
        {
            CreateMap<ProductCategoryDTO, ProductCategory>();
            CreateMap<ProductCategory, ProductCategoryDTO>();
        }
    }
}