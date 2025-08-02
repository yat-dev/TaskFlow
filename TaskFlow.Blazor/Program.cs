using TaskFlow.Blazor.Components;
using TaskFlow.Blazor.Services;

var builder = WebApplication.CreateBuilder(args);

// 🛠️ Configuration Kestrel doit être AVANT Build()
builder.WebHost.ConfigureKestrel(options => options.ListenAnyIP(80));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var apiUrl = "http://taskflow.api";

Console.WriteLine("apiUrl: " + apiUrl);

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiUrl) });
builder.Services.AddScoped<ProjectService>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddScoped<UserService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();