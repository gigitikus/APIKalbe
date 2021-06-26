using APIKalbe.Models;
using System.Collections.Generic;

namespace APIKalbe.Services
{
    public interface ICurrencyService
    {
        List<Master.Currency> GetCurrencies();
        Master.Currency GetCurrency(string CurrencyId);
    }
}
