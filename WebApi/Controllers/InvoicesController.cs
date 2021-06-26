using APIKalbe.Models;
using APIKalbe.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIKalbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;
        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpPost]
        [Route("[action]")]
        [Route("api/Invoices/AddInvoices")]
        public Invoice.ResInvoices AddInvoices(Invoice.PostInvoices postInvoices)
        {
            Invoice.ResInvoices res = new Invoice.ResInvoices();
            res = _invoiceService.PostInvoices(postInvoices);
            return res;

        }
    }
}
