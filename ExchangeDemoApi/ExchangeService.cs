using ExchangeDemoApi.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeDemoApi
{
    internal class ExchangeService : IExchangeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl; //later https://api.exchangeratesapi.io/

        public ExchangeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ExchangeRates> GetExchangeRate(string baseCurrency)
        {
            var uri = $"https://api.exchangeratesapi.io/latest?base={baseCurrency.ToUpper()}";

            var responseString = await _httpClient.GetStringAsync(uri);

            var exchangeRates = ExchangeRates.FromJson(responseString);

            return exchangeRates;
        }
    }
}