using HelpersLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AsyncIOOperations
{
    public class AsyncAwaitWithIO : IRun
    {
        public void Run()
        {
            var result = CreateAndWriteAsyncToFile();
            while (!result.IsCompleted)
                Console.WriteLine("Not Completed");
            if (result.IsCompleted)
                Console.WriteLine("Completed");

            var httpRes = ReadAsyncHttpRequest();

        }

        public async Task CreateAndWriteAsyncToFile()
        {
            using (FileStream fs = new FileStream("test.dat", FileMode.Create, FileAccess.Write, FileShare.None, 4096, true))
            {
                byte[] data = new byte[100000];
                new Random().NextBytes(data);

                await fs.WriteAsync(data, 0, data.Length);
            }
        }

        public async Task ReadAsyncHttpRequest()
        {
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync("http://www.microsoft.com");

        }
    }
}
