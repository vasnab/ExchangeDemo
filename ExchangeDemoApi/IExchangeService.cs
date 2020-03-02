using ExchangeDemoApi.Models;
using System.Threading.Tasks;

namespace ExchangeDemoApi
{
    public interface IExchangeService
    {
        Task<ExchangeRates> GetExchangeRate(string baseCurrency);
    }
}