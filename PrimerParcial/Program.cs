using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using PrimerParcial.BLL;
using PrimerParcial.DAL;
using PrimerParcial.Data;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


//DbContext de la base de datos
builder.Services.AddDbContext<Context>(options =>
options.UseSqlite(builder.Configuration.GetConnectionString("DBConnection"))
);
//Injecciones-------------------------------------------------------------

builder.Services.AddScoped<NotificationService>();

builder.Services.AddScoped<IngresosBLL>();

//-----------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
