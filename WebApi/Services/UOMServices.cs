using APIKalbe.DBContext;
using APIKalbe.Models;
using System.Collections.Generic;
using System.Linq;

namespace APIKalbe.Services
{
    public class UOMServices : IUOMServices
    {
        public UOMContext _uomContext;
        public UOMServices(UOMContext uOMContext)
        {
            _uomContext = uOMContext;
        }
        public List<Master.UnitOfMeasure> GetUnitOfMeasures()
        {
            return _uomContext.UnitOfMeasure.ToList();
        }
    }
}
