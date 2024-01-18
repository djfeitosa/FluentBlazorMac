using Microsoft.FluentUI.AspNetCore.Components;
using FluentBlazorMac.Components;
using FluentBlazorMac.Context;
using Microsoft.EntityFrameworkCore;
using FluentBlazorMac.Services.AlunoService;
using FluentBlazorMac.Services.TurmaService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddFluentUIComponents();


// var connectionString = builder.Configuration.GetConnectionString("ConnectionDesDell");
var connectionString = builder.Configuration.GetConnectionString("ConnectionDesMac");
var MySqlVersion = ServerVersion.AutoDetect(connectionString);

builder.Services.AddDbContext<AppDbContext>(x => x.UseMySql(connectionString, MySqlVersion));

builder.Services.AddScoped<IAlunoService, AlunoService>();
builder.Services.AddScoped<ITurmaService, TurmaService>();

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
