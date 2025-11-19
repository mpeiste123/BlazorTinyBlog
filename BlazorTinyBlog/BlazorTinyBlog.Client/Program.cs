using BlazorTinyBlog.Shared.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddScoped(sp => new HttpClient
{
BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)

});
builder.Services.AddScoped<IBlogPostService, ClientBlogService>();
await builder.Build().RunAsync();
