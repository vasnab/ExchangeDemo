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
    public class RatesController : ControllerBase
    {
        private readonly IExchangeService exchangeService;
        public RatesController(IExchangeService exchangeService)
        {
            this.exchangeService = exchangeService;
        }
        // GET api/rates
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/rates/usd
        [HttpGet("{baseCurrencyCode}")]
        public async Task <ActionResult<string>> Get(string baseCurrencyCode)
        {
            var result = await exchangeService.GetExchangeRate(baseCurrencyCode);
        
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
