using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreadingAndMultitasking.Helpers;

namespace ThreadingAndMultitasking.AsyncAwait
{
    public class AsyncAndAwait : IRun
    {
        public void Run()
        {
            DownloadTaskTest();
            SleepingByThreadAndByTask();
        }

        private void DownloadTaskTest()
        {
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());

            var result = DownloadContent().Result;
            Console.WriteLine(result.Substring(0, 1000));
        }

        private async Task<string> DownloadContent()
        {
            using (HttpClient client = new HttpClient())
            {
                string result = await client.GetStringAsync("https://www.microsoft.com/pl-pl/");
                return result;
            }
        }

        private void SleepingByThreadAndByTask()
        {
            /*
             * If you are building a client application that needs to stay responsive while background operations are running, 
             * you can use the await keyword to offload a long-running operation to another thread. Although this does not improve performance, 
             * it does improve responsiveness. The await keyword also makes sure that the remainder of your method runs on the correct user 
             * interface thread so you can update the user interface. Making a scalable application that uses fewer threads is another story. 
             * Making code scale better is about changing the actual implementation of the code.
             * */
            StaticValues.WriteMethodName(MethodBase.GetCurrentMethod());
            SleepAsyncA(1000);
            SleepAsyncB(1000);
            /*The SleepAsyncA method uses a thread from the thread pool while sleeping. 
             * The second method, however, which has a completely different implementation, 
             * does not occupy a thread while waiting for the timer to run. 
             * The second method gives you scalability.
             */
        }

        private Task SleepAsyncA(int millisecondsTimeout)
        {
            Console.WriteLine("SleepAsyncA");
            return Task.Run(() => Thread.Sleep(millisecondsTimeout));
        }
        private Task SleepAsyncB(int millisecondsTimeout)
        {
            Console.WriteLine("SleepAsyncB");
            TaskCompletionSource<bool> tcs = null;
            var t = new Timer(delegate { tcs.TrySetResult(true); }, null, -1, -1);
            tcs = new TaskCompletionSource<bool>(t);
            t.Change(millisecondsTimeout, -1);
            return tcs.Task;
        }


    }
}
