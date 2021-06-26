using System;

namespace AppKalbe.Models
{
    public class Invoices
    {
        public class Header
        {
            public string InvoiceNo { get; set; }
            public string Language { get; set; }
            public string Currency { get; set; }
            public string Sender { get; set; }
            public string Recipient { get; set; }
            public DateTime InvoiceDate { get; set; }
            public DateTime InvoiceDue { get; set; }
            public bool IsImmediately { get; set; }
            public string PurchaseOrderNo { get; set; }
            public decimal Discount { get; set; }
        }
        public class Lines
        {
            public string InvoiceNo { get; set; }
            public int InvoiceLineNo { get; set; }
            public string ItemName { get; set; }
            public decimal Quantity { get; set; }
            public decimal Rate { get; set; }
            public decimal Amount { get; set; }
            public string UOM { get; set; }

        }
        public class PostInvoices
        {
            public Header Header { get; set; }
            public Lines Lines { get; set; }
        }
        public class ResInvoices
        {
            public string Status { get; set; }
            public string Message { get; set; }
            public string Error { get; set; }
        }
    }
}
