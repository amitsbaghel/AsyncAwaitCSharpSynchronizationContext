using Nito.AsyncEx;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncAwaitInSynchronizationContextCSharp
{
    class Program
    {
        static async Task Main(string[] args)
        {
			// Installed this Nuget package to create a SynchronizationContext https://www.nuget.org/packages/Nito.AsyncEx.Context/
			// to mimic the behavior like WinForms apps and WPF
			// Followed this link and couple more - https://stackoverflow.com/questions/70917489/why-is-the-current-thread-changed-when-a-task-awaits-another-task
			AsyncContext.Run(async () =>
			{
				await new Method().CallAsyncMethods();

				// Task.Run creates different thread regardless it is being called from an application which creates SynchronizationContext
				// await Task.Run(() => new Method().CallAsyncMethods());
			});

			Console.WriteLine("-------------------------------------------------------------------------------");

			await new Method().CallAsyncMethods();
			Console.ReadKey();
		}
    }
	public class Method
	{

		public async Task CallAsyncMethods()
		{
			Console.WriteLine($"Thread Id initially: {Thread.CurrentThread.ManagedThreadId}");

			await new Download().DownloadString("https://google.com/");

			Console.WriteLine($"Thread Id after DownloadString call in Main: {Thread.CurrentThread.ManagedThreadId}");

			await new First().FirstAsyncCall();

			Console.WriteLine($"Thread Id after all calls in Main: {Thread.CurrentThread.ManagedThreadId}");
		}
	}


	public class Download
	{
		public async Task<string> DownloadString(string url)
		{
			Console.WriteLine($"Thread Id inside DownloadString call before calling GetAsync: {Thread.CurrentThread.ManagedThreadId}");

			var client = new HttpClient();
			var request = await client.GetAsync(url);

			Console.WriteLine($"Thread Id inside DownloadString call after calling GetAsync: {Thread.CurrentThread.ManagedThreadId}");

			var download = await request.Content.ReadAsStringAsync();
			return download;
		}
	}

	public class First
	{
		public async Task<string> FirstAsyncCall()
		{
			Console.WriteLine($"Thread Id inside FirstAsyncCall call before Task Delay: {Thread.CurrentThread.ManagedThreadId}");

			await Task.Delay(1000);

			Console.WriteLine($"Thread Id inside FirstAsyncCall call after Task Delay: {Thread.CurrentThread.ManagedThreadId}");

			return "First call";
		}
	}
}
