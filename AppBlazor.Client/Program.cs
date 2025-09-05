using AppBlazor.Client;
using AppBlazor.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Registrar los servicios
builder.Services.AddScoped<LibroService>();
builder.Services.AddScoped<TipoLibroService>();  // Aquí es donde registramos el servicio TipoLibroService

await builder.Build().RunAsync();
