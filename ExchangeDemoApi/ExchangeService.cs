using ExchangeDemoApi.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeDemoApi
{
    internal class ExchangeService : IExchangeService
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteServiceBaseUrl; 

        public ExchangeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _remoteServiceBaseUrl = "https://api.exchangeratesapi.io/";
        }

        public async Task<ExchangeRates> GetExchangeRate(string baseCurrency)
        {
            var uri = $"{_remoteServiceBaseUrl}latest?base={baseCurrency.ToUpper()}";

            var responseString = await _httpClient.GetStringAsync(uri);

            var exchangeRates = ExchangeRates.FromJson(responseString);

            return exchangeRates;
        }

        public async Task<ExchangeRates> GetExchangeRateForPair(string masterCurrency, string slaveCurrency)
        {
            var uri = $"{_remoteServiceBaseUrl}latest?base={masterCurrency.ToUpper()}&symbols={slaveCurrency.ToUpper()}";

            var responseString = await _httpClient.GetStringAsync(uri);

            var exchangeRates = ExchangeRates.FromJson(responseString);

            return exchangeRates;
        }

        public async Task<ExchangeRates> GetLatest()
        {
            var uri = $"{_remoteServiceBaseUrl}latest";

            var responseString = await _httpClient.GetStringAsync(uri);

            var exchangeRates = ExchangeRates.FromJson(responseString);

            return exchangeRates;
        }
    }
}