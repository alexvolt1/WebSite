using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebSite.Utility;

namespace WebSite.Helper
{
    public class ExpressoApiHelper
    {
        private IConfigurationRoot _configuration;
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri(SD.ClientBaseAddress);
            return Client;
        }
    }
}
