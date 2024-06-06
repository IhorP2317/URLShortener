
using Microsoft.Extensions.FileProviders;
using URLShortener.Presentation.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ConfigureSqlConnection(builder);
builder.Services.ConfigureSeedOptions(builder);
builder.Services.ConfigureServices();
builder.Services.ConfigureAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); 



app.UseRouting();
app.UseCors("AllowSpecificOrigins"); 
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Login}/{id?}");

    // Catch-all route to serve the Angular app
    endpoints.MapFallbackToController("Index", "Url");
});

app.Run();