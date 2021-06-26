using System;
using System.ComponentModel.DataAnnotations;

namespace APIKalbe.Models
{
    public class Transactions
    {
        public class POHeader
        {
            [Key]
            public string PONumber { get; set; }
            public DateTime PODate { get; set; }
            public string CompanyName { get; set; }
            public string CurrencyId { get; set; }
            public string PIC { get; set; }
        }

    }
}
