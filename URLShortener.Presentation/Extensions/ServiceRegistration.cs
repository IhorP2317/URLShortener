using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

using URLShortener.Bussiness;
using URLShortener.Bussiness.Implementations;
using URLShortener.Bussiness.Interfaces;
using URLShortener.Domain.Data;
using URLShortener.Domain.Implementations;
using URLShortener.Domain.Interfaces;

namespace URLShortener.Presentation.Extensions;

public static class ServiceRegistration
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IUrlService, UrlService>();
        services.AddScoped<IAboutMessageService, AboutMessageService>();
        
    }

    public static void ConfigureAuthentication(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(o =>
            {
                o.LoginPath = new PathString("/Home/Login");
                o.AccessDeniedPath = new PathString("/Home/Login");
            });
    }

    public static void ConfigureSqlConnection(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddDbContext<ApplicationDbContext>(opts =>
            opts.UseSqlServer(builder.Configuration.GetConnectionString(Constants.SqlConnection)));
    }

    public static void ConfigureSeedOptions(this IServiceCollection services, WebApplicationBuilder builder)
    {
        builder.Services.Configure<AdminSeedData>(builder.Configuration.GetSection(Constants.AdminSeedData));
        builder.Services.Configure<AboutMessageSeedData>(builder.Configuration.GetSection(Constants.AboutMessageSeedData));
    }

    public static void ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigins",
                builder =>
                {
                    builder.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });

    }
}