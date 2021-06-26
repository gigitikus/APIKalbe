namespace AppKalbe.Models
{
    public class Master
    {
        public class Language
        {
            public string LanguageId { get; set; }
            public string LanguageName { get; set; }
            public int OrderNo { get; set; }
        }

        public class Currency
        {
            public string CurrencyId { get; set; }
            public string CurrencyName { get; set; }
            public int OrderNo { get; set; }
        }
        public class UnitOfMeasure
        {
            public string UOMId { get; set; }
            public string UOMName { get; set; }
            public int OrderNo { get; set; }
        }
        public class Customer
        {
            public string CustomerId { get; set; }
            public string CompanyName { get; set; }
            public string ContactPerson { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string City { get; set; }
            public string ContactNo { get; set; }
            public string EmailAddress { get; set; }
            public byte[] CompanyLogo { get; set; }
        }
        public class NoSeries
        {
            public string DocumentType { get; set; }
            public string Prefix { get; set; }
            public string Separator { get; set; }
            public string LastCounter { get; set; }
        }
        public class reqCustomer
        {
            public string CustomerId { get; set; }
        }
    }
}
