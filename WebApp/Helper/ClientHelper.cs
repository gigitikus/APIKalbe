using System;
using System.Net.Http;

namespace AppKalbe.Helper
{
    public class ClientHelper
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:42474/api/");
            return client;
        }
    }
}
