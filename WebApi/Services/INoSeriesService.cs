using APIKalbe.Models;
using System.Collections.Generic;

namespace APIKalbe.Services
{
    public interface INoSeriesService
    {
        List<Master.NoSeries> GetNoSeries();
    }
}
