global using MechanicApp.Client.Services.CustomerService;
global using MechanicApp.Client.Services.JobService;
global using MechanicApp.Shared;
global using MechanicApp.Client.Services.PartService;
using MechanicApp.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazorise;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IJobService, JobService>();
builder.Services.AddScoped<IPartService, PartService>();

builder.Services
    .AddBlazorise(options =>
    {
        options.ModalFocusTrap = true; // Customize options as needed
    });

await builder.Build().RunAsync();
