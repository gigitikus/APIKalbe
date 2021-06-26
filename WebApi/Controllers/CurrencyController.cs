using APIKalbe.Models;
using APIKalbe.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APIKalbe.Controllers
{
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;
        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Currency/GetCurrencies")]
        public IEnumerable<Master.Currency> GetCurrencies()
        {
            return _currencyService.GetCurrencies().OrderBy(c => c.OrderNo);
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/Currency/GetCurrency/{CurrencyId?}")]
        public Master.Currency GetCurrency(string CurrencyId)
        {
            return _currencyService.GetCurrency(CurrencyId);
        }
    }
}
