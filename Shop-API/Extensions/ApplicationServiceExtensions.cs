using Microsoft.EntityFrameworkCore;
using Shop_API.Data;
using Shop_API.Interfaces;
using Shop_API.Services;

namespace Shop_API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseNpgsql(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        
        return services;
    }
}