using AutoMapper;
using Shop.API.CQRS.Handlers.Interfaces;
using Shop.API.CQRS.Queries.ExternalServices;
using Shop.Domain.Enums;
using Shop.Infrastructure.Models;
using Shop.Infrastructure.Services.Interfaces;
using Shop.Shared.Dtos.ExternalServices;

namespace Shop.API.CQRS.Handlers
{
    public class ExternalServicesHandler :
        IQueryBaseHandler<GetCurrencyRateQuery, RateDTO>,
        IQueryBaseHandler<GetSupportedCurrenciesQuery, IList<SupportedCurrency>>
    {
        private readonly IMapper _mapper;
        private readonly INBPService _nbpService;

        private IList<string> SupportedCurrencies = new List<string>(){
                SupportedCurrency.USD.ToString(),
                SupportedCurrency.EUR.ToString(),
                SupportedCurrency.CZK.ToString(),
                SupportedCurrency.GBP.ToString()};
        public ExternalServicesHandler(IMapper mapper, INBPService nbpService)
        {
            _mapper = mapper;
            _nbpService = nbpService;
        }

        public async Task<RateDTO> HandleAsync(GetCurrencyRateQuery command)
        {
            if (!SupportedCurrencies.Contains(command.CurrencyCode))
            {
                throw new NotImplementedException();
            }

            var currencyRates = await _nbpService.GetSupportedCurrenciesRatesAsync();

            return _mapper.Map<RateDTO>(currencyRates.SelectMany(data => data.Rates)
                   .FirstOrDefault(rate => rate.Code == command.CurrencyCode));
        }

        public Task<IList<SupportedCurrency>> HandleAsync(GetSupportedCurrenciesQuery command)
        {
            throw new NotImplementedException();
        }
    }
}

