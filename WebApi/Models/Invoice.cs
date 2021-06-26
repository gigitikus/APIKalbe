using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace APIKalbe.Models
{
    public class Invoice
    {
        public class Header
        {
            [Key]
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
            [Key]
            public string InvoiceNo { get; set; }
            [Key]
            public int InvoiceLineNo { get; set; }
            public string ItemName { get; set; }
            public decimal Quantity { get; set; }
            public decimal Rate { get; set; }
            public decimal Amount { get; set; }
            public string UOM { get; set; }
        }
        public class PostInvoices
        {
            public Header header { get; set; }
            public List<Lines> lines { get; set; }
        }
        public class ResInvoices
        {
            public string Status { get; set; }
            public string Message { get; set; }
            public string Error { get; set; }
        }

    }
}
