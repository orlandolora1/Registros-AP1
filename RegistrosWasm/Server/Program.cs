using Microsoft.AspNetCore.ResponseCompression;
using RegistrosWasm.Server.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var ConStr = builder.Configuration.GetConnectionString("ConStr");
builder.Services.AddDbContextFactory<PrioridadContext>(options => options.UseSqlite(ConStr));

var Client = builder.Configuration.GetConnectionString("Client");
builder.Services.AddDbContextFactory<ClientesContext>(options => options.UseSqlite(Client));

var Tick = builder.Configuration.GetConnectionString("Tick");
builder.Services.AddDbContextFactory<TicketContext>(options => options.UseSqlite(Tick));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
