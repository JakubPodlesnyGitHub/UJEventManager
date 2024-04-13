using Microsoft.Extensions.Configuration;
using Shop.Infrastructure.Models;
using Shop.Infrastructure.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Services 
{
    public class NBPService : INBPService
    {
        private IConfiguration _configuration;
        private readonly HttpClient _httpClient = new HttpClient();

        public NBPService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<ExchangeRateTable>> GetSupportedCurrenciesRatesAsync()
        {
            HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(_configuration.GetSection("NBP:URL").Value);
            string response = string.Empty;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                response = await httpResponseMessage.Content.ReadAsStringAsync();
                return DeserializeJson(response);
            }
            return null;
        }

        private List<ExchangeRateTable> DeserializeJson(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if (string.IsNullOrEmpty(json))
            {
                return default;
            }

            return JsonSerializer.Deserialize<List<ExchangeRateTable>>(json, options);
        }
    }
}
