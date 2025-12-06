using MudBlazor.Services;
using WireMockUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

// Register WireMock services
builder.Services.AddHttpClient<IWireMockService, WireMockService>(client =>
{
    var wireMockUrl = builder.Configuration["WireMock:BaseUrl"] ?? "http://localhost:9091";
    client.BaseAddress = new Uri(wireMockUrl);
});

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
