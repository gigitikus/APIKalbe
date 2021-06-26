using APIKalbe.Models;

namespace APIKalbe.Services
{
    public interface IInvoiceService
    {
        Invoice.ResInvoices PostInvoices(Invoice.PostInvoices postInvoices);
    }
}
