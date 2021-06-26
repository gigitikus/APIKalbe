using APIKalbe.DBContext;
using APIKalbe.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APIKalbe.Services
{
    public class POHeaderService : IPOHeaderService
    {
        public POHeaderContext _pOHeaderContext;
        public POHeaderService(POHeaderContext pOHeaderContext)
        {
            _pOHeaderContext = pOHeaderContext;
        }
        public List<Transactions.POHeader> GetPOHeaders(string CustomerId)
        {
            List<Transactions.POHeader> pOHeaders = new List<Transactions.POHeader>();

            var s = _pOHeaderContext.PurchaseOrderHeader.FromSqlRaw("SELECT " +
                    "po.[PONumber]" +
                    ",po.[PODate]" +
                    ",cus.[CompanyName]" +
                    ",po.[CurrencyId]" +
                    ",po.[PIC]" +
                    " FROM" +
                    " [dbo].[PurchaseOrderHeader] po" +
                    " inner join" +
                    " [dbo].[Customer] cus" +
                    " ON po.[CustomerId] = cus.[CustomerId]" +
                    " WHERE po.[CustomerId] = '" + CustomerId.Trim() + "'").ToList();

            pOHeaders = s;

            return pOHeaders;
        }
        public Transactions.POHeader GetPOHeader(string PONumber)
        {
            Transactions.POHeader pOHeaders = new Transactions.POHeader();

            var s = _pOHeaderContext.PurchaseOrderHeader.FromSqlRaw("SELECT " +
                    "po.[PONumber]" +
                    ",po.[PODate]" +
                    ",cus.[CompanyName]" +
                    ",po.[CurrencyId]" +
                    ",po.[PIC]" +
                    " FROM" +
                    " [dbo].[PurchaseOrderHeader] po" +
                    " inner join" +
                    " [dbo].[Customer] cus" +
                    " ON po.[CustomerId] = cus.[CustomerId]" +
                    " WHERE" +
                    " RTRIM(po.[PONumber]) = '" + PONumber.Trim() + "'").FirstOrDefault();
            pOHeaders = s;
            return pOHeaders;
        }
    }
}
