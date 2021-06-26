using AppKalbe.Helper;
using AppKalbe.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AppKalbe.Controllers
{
    public class InvoiceController : Controller
    {
        ClientHelper _api = new ClientHelper();
        public async Task<IActionResult> Invoice()
        {
            var taskLanguages = GetLanguages();
            var taskCurrency = GetCurrencies();
            var taskUOM = GetGetUnitOfMeasures();
            var taskCustomer = GetCustomers();
            var taskInvNo = GetNoSeries();
            await Task.WhenAll(taskLanguages, taskCurrency, taskUOM, taskCustomer, taskInvNo);

            List<Master.Language> languages = taskLanguages.Result;
            List<Master.Currency> currencies = taskCurrency.Result;
            List<Master.UnitOfMeasure> unitOfMeasures = taskUOM.Result;
            List<Master.Customer> customers = taskCustomer.Result;
            string InvNo = taskInvNo.Result.ToString();

            ViewBag.Languages = languages;
            ViewBag.Currencies = currencies;
            ViewBag.UOM = unitOfMeasures;
            ViewBag.Customers = customers;
            ViewBag.InvoiceNo = InvNo;

            return View();
        }

        public async Task<List<Master.Language>> GetLanguages()
        {
            List<Master.Language> languages = new List<Master.Language>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("Language/GetLanguages");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                languages = JsonConvert.DeserializeObject<List<Master.Language>>(result);
            }
            return languages;
        }
        public async Task<List<Master.Currency>> GetCurrencies()
        {
            List<Master.Currency> currencies = new List<Master.Currency>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("Currency/GetCurrencies");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                currencies = JsonConvert.DeserializeObject<List<Master.Currency>>(result);
            }
            return currencies;
        }
        public async Task<List<Master.UnitOfMeasure>> GetGetUnitOfMeasures()
        {
            List<Master.UnitOfMeasure> unitOfMeasures = new List<Master.UnitOfMeasure>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("UOM/GetUnitOfMeasures");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                unitOfMeasures = JsonConvert.DeserializeObject<List<Master.UnitOfMeasure>>(result);
            }
            return unitOfMeasures;
        }
        public async Task<List<Master.Customer>> GetCustomers()
        {
            List<Master.Customer> customers = new List<Master.Customer>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("Customer/GetCustomers");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                customers = JsonConvert.DeserializeObject<List<Master.Customer>>(result);
            }
            return customers;
        }
        public async Task<string> GetNoSeries()
        {
            string InvNo = string.Empty;
            List<Master.NoSeries> noSeries = new List<Master.NoSeries>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("NoSeries/GetNoSeries");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                noSeries = JsonConvert.DeserializeObject<List<Master.NoSeries>>(result);
            }

            InvNo = noSeries[0].Prefix + noSeries[0].Separator + noSeries[0].LastCounter;

            return InvNo;
        }

        [HttpPost]
        public async Task<JsonResult> GetCustomer(string CustomerId)
        {
            Master.Customer customer = new Master.Customer();
            if (!string.IsNullOrEmpty(CustomerId))
            {
                HttpClient client = _api.Initial();
                HttpResponseMessage res = await client.GetAsync("Customer/GetCustomer?CustomerId=" + CustomerId.Trim());
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    customer = JsonConvert.DeserializeObject<Master.Customer>(result);
                }
            }
            return Json(customer);
        }

        [HttpPost]
        public async Task<JsonResult> GetCurrency(string CurrencyId)
        {
            Master.Currency currency = new Master.Currency();
            if (!string.IsNullOrEmpty(CurrencyId))
            {
                HttpClient client = _api.Initial();
                HttpResponseMessage res = await client.GetAsync("Currency/GetCurrency?CurrencyId=" + CurrencyId.Trim());
                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    currency = JsonConvert.DeserializeObject<Master.Currency>(result);
                }
            }
            return Json(currency);
        }

        [HttpGet]
        public async Task<List<Transaction.POHeader>> GetPO(string CustomerId)
        {
            List<Transaction.POHeader> pOHeaders = new List<Transaction.POHeader>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("POHeader/GetPOHeaders?CustomerId=" + CustomerId.Trim());
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                pOHeaders = JsonConvert.DeserializeObject<List<Transaction.POHeader>>(result);
            }
            return pOHeaders;
        }

        [HttpPost]
        public async Task<Invoices.ResInvoices> AddInvoices(Invoices.PostInvoices postInvoices)
        {
            var jsonObj = new { json = postInvoices };
            var json = JsonConvert.SerializeObject(jsonObj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            Invoices.ResInvoices resInvoices = new Invoices.ResInvoices();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.PostAsync("Invoices/AddInvoices", content);
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                resInvoices = JsonConvert.DeserializeObject<Invoices.ResInvoices>(result);
            }
            else
            {
                var rawResponse = await res.Content.ReadAsStringAsync();

                JObject o = JObject.Parse(rawResponse);
            }
            return resInvoices;
        }
    }
}
