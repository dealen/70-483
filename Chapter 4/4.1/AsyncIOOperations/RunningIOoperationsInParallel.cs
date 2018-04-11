using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncIOOperations
{
    public class RunningIOoperationsInParallel : IRun
    {
        public void Run()
        {
            ExecuteMultipleRequests();
            ExecutingMultipleRequestsInParallel();
        }

        public async Task ExecuteMultipleRequests()
        {
            HttpClient client = new HttpClient();

            string microsoft = await client.GetStringAsync("http://www.microsoft.com");
            string msdn = await client.GetStringAsync("http://msdn.microsoft.com");
            string blogs = await client.GetStringAsync("http://blogs.msdn.com/");
        }

        public async Task ExecutingMultipleRequestsInParallel()
        {
            HttpClient client = new HttpClient();

            Task microsoft = client.GetStringAsync("http://www.microsoft.com");
            Task msdn = client.GetStringAsync("http://msdn.microsoft.com");
            Task blogs = client.GetStringAsync("http://blogs.msdn.com/");

            await Task.WhenAll(microsoft, msdn, blogs);
        }
    }
}
