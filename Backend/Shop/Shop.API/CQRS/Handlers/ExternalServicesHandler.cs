using AutoMapper;
using MediatR;
using Shop.API.CQRS.Queries.ExternalServices;
using Shop.Domain.Enums;
using Shop.Infrastructure.Services.Interfaces;
using Shop.Shared.Dtos.ExternalServices;

namespace Shop.API.CQRS.Handlers
{
    public class ExternalServicesHandler :
        IRequestHandler<GetCurrencyRateQuery, RateDTO>,
        IRequestHandler<GetSupportedCurrenciesQuery, IList<SupportedCurrency>>
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

        public Task<IList<SupportedCurrency>> Handle(GetSupportedCurrenciesQuery request, CancellationToken cancellationToken)
        {
            return (Task<IList<SupportedCurrency>>)SupportedCurrencies;
        }

        public async Task<RateDTO> Handle(GetCurrencyRateQuery request, CancellationToken cancellationToken)
        {
            var allowedCurrencies = SupportedCurrencies.Select(x => x.ToString().ToLower()).ToList();
            if (!allowedCurrencies.Contains(request.CurrencyCode.ToLower()))
            {
                throw new NotImplementedException();
            }

            var currencyRates = await _nbpService.GetSupportedCurrenciesRatesAsync();

            return _mapper.Map<RateDTO>(currencyRates.SelectMany(data => data.Rates)
                   .FirstOrDefault(rate => rate.Code.ToLower() == request.CurrencyCode.ToLower()));
        }
    }
}