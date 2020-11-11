using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using harmonyexplorer.Shared;
using harmonyexplorer;

namespace harmonyexplorer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //await DebugDelayAsync();
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            await builder.Build().RunAsync();
        }
        private static async Task DebugDelayAsync()
        {

            await Task.Delay(5000);

        }
    }
}
