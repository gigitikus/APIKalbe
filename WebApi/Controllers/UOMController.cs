using APIKalbe.Models;
using APIKalbe.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace APIKalbe.Controllers
{
    public class UOMController : ControllerBase
    {
        private readonly IUOMServices _uOMServices;
        public UOMController(IUOMServices uOMServices)
        {
            _uOMServices = uOMServices;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/UOM/GetUnitOfMeasures")]
        public IEnumerable<Master.UnitOfMeasure> GetUnitOfMeasures()
        {
            return _uOMServices.GetUnitOfMeasures().OrderBy(c => c.OrderNo);
        }
    }
}
