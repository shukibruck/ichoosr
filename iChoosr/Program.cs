using iChoosr.Api;
using iChoosr.Application;
using iChoosr.Domain;
using iChoosr.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
services.AddControllersWithViews();
services.AddDomain();
services.AddInfrastructure();
services.AddApplication();
services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:44443")
            .AllowAnyHeader()
            .AllowAnyMethod());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseCLICameraSearchService(builder.Configuration, app.Services);
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowSpecificOrigin");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
