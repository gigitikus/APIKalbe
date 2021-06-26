using APIKalbe.Models;
using System.Collections.Generic;

namespace APIKalbe.Services
{
    public interface IUOMServices
    {
        List<Master.UnitOfMeasure> GetUnitOfMeasures();
    }
}
