using BlazorDemo.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlazorDemo.Data;
using BlazorDemo.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContextFactory<BlazorDemoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BlazorDemoContext") ?? throw new InvalidOperationException("Connection string 'BlazorDemoContext' not found.")));

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
