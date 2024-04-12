using Shop.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Services.Interfaces
{
    public interface INBPService
    {
        Task<List<ExchangeRateTable>> GetSupportedCurrenciesRatesAsync();
    }
}
