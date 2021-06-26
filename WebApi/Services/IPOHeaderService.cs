using APIKalbe.Models;
using System.Collections.Generic;

namespace APIKalbe.Services
{
    public interface IPOHeaderService
    {
        List<Transactions.POHeader> GetPOHeaders(string CustomerId);
        Transactions.POHeader GetPOHeader(string PONumber);
    }
}
