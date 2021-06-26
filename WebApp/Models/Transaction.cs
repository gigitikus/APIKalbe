using System;

namespace AppKalbe.Models
{
    public class Transaction
    {
        public class POHeader
        {
            public string PONumber { get; set; }
            public DateTime PODate { get; set; }
            public string CompanyName { get; set; }
            public string CurrencyId { get; set; }
            public string PIC { get; set; }
        }
    }
}
