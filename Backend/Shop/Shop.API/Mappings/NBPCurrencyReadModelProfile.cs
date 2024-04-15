using AutoMapper;
using Shop.Infrastructure.Models;
using Shop.Shared.Dtos.ExternalServices;

namespace Shop.API.Mappings
{
    public class NBPCurrencyReadModelProfile : Profile
    {
        public NBPCurrencyReadModelProfile()
        {
            CreateMap<ExchangeRateTable, ExchangeRateTableDTO>();
            CreateMap<Rate, RateDTO>();
        }
    }
}
