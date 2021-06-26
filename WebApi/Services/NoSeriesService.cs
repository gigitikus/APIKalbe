using APIKalbe.DBContext;
using APIKalbe.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace APIKalbe.Services
{
    public class NoSeriesService : INoSeriesService
    {
        public NoSeriesContext _noSeriesContext;
        public NoSeriesService(NoSeriesContext noSeriesContext)
        {
            _noSeriesContext = noSeriesContext;
        }

        public List<Master.NoSeries> GetNoSeries()
        {
            List<Master.NoSeries> noSeries = new List<Master.NoSeries>();

            var s = _noSeriesContext.NoSeries.FromSqlRaw("BEGIN TRAN " +
                        "UPDATE " +
                        "[TestKalbeDB].[dbo].[NoSeries] " +
                        "WITH(ROWLOCK) " +
                        "SET [LastCounter] = " +
                        "(" +
                            "select " +
                            "LastCounter + 1 " +
                            "from " +
                            "[TestKalbeDB].[dbo].[NoSeries]" +
                            "WHERE [DocumentType] = 'Invoice' " +
                        ") " +
                        "COMMIT " +
                        "SELECT " +
                            "DocumentType" +
                            ",Prefix" +
                            ",Separator" +
                            ",FORMAT(LastCounter, '000000') as LastCounter " +
                        "FROM " +
                        "[TestKalbeDB].[dbo].[NoSeries] " +
                        "where [DocumentType] = 'Invoice'").ToList();

            noSeries = s;
            return noSeries;
        }
    }
}
