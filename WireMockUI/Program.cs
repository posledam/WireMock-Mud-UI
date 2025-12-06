using MudBlazor.Services;
using RestEase.HttpClientFactory;
using WireMock.Client;
using WireMockUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

// Register WireMock services
var wireMockUrl = builder.Configuration["WireMock:BaseUrl"] ?? "http://localhost:9091";
builder.Services.AddRestEaseClient<IWireMockAdminApi>(wireMockUrl);
builder.Services.AddScoped<IWireMockService, WireMockService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<WireMockUI.Components.App>()
    .AddInteractiveServerRenderMode();

app.Run();
