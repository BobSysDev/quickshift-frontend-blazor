using Microsoft.AspNetCore.Components.Authorization;
using QuickShiftUI.Components;
using QuickShiftUI.Components.Auth;
using QuickShiftUI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IShiftService, HttpShiftService>();
builder.Services.AddScoped<IShiftSwitchRequestService, HttpShiftSwitchRequestService>();
builder.Services.AddScoped<IShiftSwitchReplyService, HttpShiftSwitchReplyService>();
builder.Services.AddScoped<IEmployeeService, HttpEmployeeService>();
builder.Services.AddScoped<IAnnouncementService, HttpAnnouncementService>();


builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthProvider>();
// builder.Services.AddScoped<SimpleAuthProvider>(); 

builder.Services.AddScoped(sp => new HttpClient
{ 
    BaseAddress = new Uri("https://quickshift.electimore.xyz")
    // BaseAddress = new Uri("http://localhost:5070")
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();