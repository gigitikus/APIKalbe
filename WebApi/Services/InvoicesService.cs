using APIKalbe.DBContext;
using APIKalbe.Models;

namespace APIKalbe.Services
{
    public class InvoicesService : IInvoiceService
    {
        public InvoiceContext _InvoiceContext;
        public InvoicesService(InvoiceContext invoiceContext)
        {
            _InvoiceContext = invoiceContext;
        }

        public Invoice.ResInvoices PostInvoices(Invoice.PostInvoices postInvoices)
        {
            Invoice.ResInvoices result = new Invoice.ResInvoices();

            var context = _InvoiceContext;
            var transaction = context.Database.BeginTransaction();

            try
            {
                //insert to invoice header
                _InvoiceContext.InvoiceHeader.Add(postInvoices.header);
                _InvoiceContext.SaveChanges();

                //insert to invoice lines
                Invoice.Lines line = new Invoice.Lines();
                foreach (var item in postInvoices.lines)
                {
                    line.InvoiceNo = item.InvoiceNo;
                    line.InvoiceLineNo = item.InvoiceLineNo;
                    line.ItemName = item.ItemName;
                    line.Quantity = item.Quantity;
                    line.Rate = item.Rate;
                    line.Amount = item.Amount;
                    line.UOM = item.UOM;

                    _InvoiceContext.InvoiceLine.Add(line);

                }
                _InvoiceContext.SaveChanges();

                transaction.Commit();

                result.Status = "200";
                result.Message = "Insert Successfull";
                result.Error = "";
            }
            catch (System.Exception ex)
            {
                result.Status = "400";
                result.Message = "Failed to insert";
                result.Error = ex.Message;
                transaction.Rollback();
            }

            return result;
        }
    }
}
