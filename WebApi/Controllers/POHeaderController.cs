using APIKalbe.Models;
using APIKalbe.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APIKalbe.Controllers
{
    public class POHeaderController : ControllerBase
    {
        private readonly IPOHeaderService _pOHeaderService;
        public POHeaderController(IPOHeaderService pOHeaderService)
        {
            _pOHeaderService = pOHeaderService;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/POHeader/GetPOHeaders/{CustomerId?}")]
        public IEnumerable<Transactions.POHeader> GetPOHeaders(string CustomerId)
        {
            return _pOHeaderService.GetPOHeaders(CustomerId).OrderBy(c => c.PODate);
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/POHeader/GetPOHeader/{PONumber?}")]
        public Transactions.POHeader GetPOHeader(string PONumber)
        {
            return _pOHeaderService.GetPOHeader(PONumber);
        }
    }
}
