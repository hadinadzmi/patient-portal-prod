//using Blazored.LocalStorage;
//using Blazored.Modal;
//using Microsoft.AspNetCore.Components.Web;
//using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
//using Patient_Portal;

//var builder = WebAssemblyHostBuilder.CreateDefault(args);
//builder.RootComponents.Add<App>("#app");
//builder.RootComponents.Add<HeadOutlet>("head::after");
//builder.Services.AddSingleton<ActivePageService>();


//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//await builder.Build().RunAsync();

using Blazored.LocalStorage;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Patient_Portal;
using Patient_Portal.Core;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");
        builder.Services.AddSingleton<ActivePageService>();

        builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
        builder.Services.AddBlazoredModal();
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddLocalization();
        //NEW
        builder.Services.AddTelerikBlazor();
        await LoadMedCubesInitParams(builder);
        await builder.Build().RunAsync();
    }

    private static async Task LoadMedCubesInitParams(WebAssemblyHostBuilder builder)
    {
        var client = new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
        // the appsettings file must be in 'wwwroot'
        using (var response = await client.GetAsync("appsettings.json"))
        {
            using (var stream = await response.Content.ReadAsStreamAsync())
            {
                builder.Configuration.AddJsonStream(stream);
                GlobalData.SetGlobalData(builder.Configuration);
            }
        }
    }
}