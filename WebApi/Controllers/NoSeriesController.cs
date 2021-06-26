using APIKalbe.Models;
using APIKalbe.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace APIKalbe.Controllers
{
    public class NoSeriesController : ControllerBase
    {
        private readonly INoSeriesService _noSeriesService;
        public NoSeriesController(INoSeriesService noSeriesService)
        {
            _noSeriesService = noSeriesService;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("api/NoSeries/GetNoSeries")]
        public List<Master.NoSeries> GetNoSeries()
        {
            /*
            using (var context = new NoSeriesContext())
            {
                var noSeries = context.NoSeries.FromSqlRaw("BEGIN TRAN " +
                        "UPDATE" +
                        "[TestKalbeDB].[dbo].[NoSeries]" +
                        "WITH(ROWLOCK)" +
                        "SET[LastCounter] = " +
                        "(" +
                            "select" +
                            "LastCounter + 1" +
                            "from" +
                            "[TestKalbeDB].[dbo].[NoSeries]" +
                        ")" +
                        "WHERE[DocumentType] = '/Invoice'/" +
                        "COMMIT" +
                        "SELECT" +
                            "Prefix" +
                            ",Separator" +
                            ",FORMAT(LastCounter, '/000000'/) as LastCounter" +
                        "FROM" +
                        "[TestKalbeDB].[dbo].[NoSeries]" +
                        "where[DocumentType] = '/Invoice'/");
            }
            */

            return _noSeriesService.GetNoSeries();
        }
    }
}
