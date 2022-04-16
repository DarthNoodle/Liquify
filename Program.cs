using AntDesign.ProLayout;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MetaMask.Blazor;
using Liquify.Code.Util;
using Liquify.Code.Storage;
using Blazored.LocalStorage;
using Liquify.Code.Util.SolidUtils;

namespace Liquify
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddAntDesign();

            builder.Services.AddMetaMaskBlazor();
            builder.Services.AddBlazoredLocalStorage();


            builder.Services.AddScoped<IDataStorage, DataStorage>();


            builder.Services.AddSingleton<AccountStateContainer>();
            builder.Services.AddSingleton<SolidPoker>();
            builder.Services.Configure<ProSettings>(builder.Configuration.GetSection("ProSettings"));

            await builder.Build().RunAsync();
        }
    }
}