using APIKalbe.DBContext;
using APIKalbe.Models;
using System.Collections.Generic;
using System.Linq;

namespace APIKalbe.Services
{
    public class CurrencyServices : ICurrencyService
    {
        public CurrencyContext _currencyContext;
        public CurrencyServices(CurrencyContext currencyContext)
        {
            _currencyContext = currencyContext;
        }
        public List<Master.Currency> GetCurrencies()
        {
            return _currencyContext.Currency.ToList();
        }
        public Master.Currency GetCurrency(string CurrencyId)
        {
            return _currencyContext.Currency.FirstOrDefault(x => x.CurrencyId.Trim() == CurrencyId);
        }
    }
}
