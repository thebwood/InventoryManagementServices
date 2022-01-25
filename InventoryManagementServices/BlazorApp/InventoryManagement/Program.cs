using InventoryManagement;
using InventoryManagement.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<MoviesService>();
builder.Services.AddSingleton<GamesService>();
builder.Services.AddSingleton<PeopleService>();
builder.Services.AddSingleton<InventoryService>();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
