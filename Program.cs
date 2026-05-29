using CustomerApp.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Database - connection string stored in appsettings.json for security
builder.Services.AddDbContext<CustomerAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerApp_DB")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Customer/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
