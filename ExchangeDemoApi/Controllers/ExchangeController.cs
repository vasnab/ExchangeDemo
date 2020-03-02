using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExchangeDemoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeDemoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService exchangeService;
        public ExchangeController(IExchangeService exchangeService)
        {
            this.exchangeService = exchangeService;
        }
        // GET api/exchange
        [HttpGet]
        public async Task <ActionResult<string>> Get()
        {
            var result = await exchangeService.GetLatest();

            return result.ToJson();
        }

        // GET api/exchange/usd
        [HttpGet("{baseCurrencyCode}")]
        public async Task <ActionResult<string>> Get(string baseCurrencyCode)
        {
            var result = await exchangeService.GetExchangeRate(baseCurrencyCode);
        
            return result.ToJson();
        }

        // GET api/exchange/usd/eur
        [HttpGet("{masterCurrencyCode}/{slaveCurrencyCode}")]
        public async Task<ActionResult<string>> Get(string masterCurrencyCode, string slaveCurrencyCode)
        {
            var result = await exchangeService.GetExchangeRateForPair(masterCurrencyCode, slaveCurrencyCode);

            return result.ToJson();
        }




        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
