
using Context;
using Context.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Repository;
using Repository.Interface;
using Service;
using Service.Interface;


namespace Ioc.Api
{
    public static class Ioc
    {
        public static IServiceCollection ConfigureInjectionDependencyRepository(this IServiceCollection services)
        {
            services.AddScoped<ItemIRepository, ItemRepository>();
            services.AddScoped<MaterialIRepository, MaterialRepository>();
            services.AddScoped<ColorIRepository, ColorRepository>();
            services.AddScoped<CategoryIRepository, CategoryRepository>();
            services.AddScoped<UserIRepository, UserRepository>();
            services.AddScoped<AdressIRepository, AdressRepository>();
            services.AddScoped<RoleIRepository, RoleRepository>();
            services.AddScoped<RoleUserIRepository, RoleUserRepository>();


            return services;
        }
        public static IServiceCollection ConfigureInjectionDependencyService(this IServiceCollection services)
        {
            services.AddScoped<ConnectionIService, ConnectionService>();
            services.AddScoped<ItemIService, ItemService>();
            services.AddScoped<ColorIService, ColorService>();
            services.AddScoped<CategoryIService, CategoryService>();
            services.AddScoped<UserIService, UserService>();
            services.AddScoped<RoleIService, RoleService>();
            services.AddScoped<AdressIService, AdressService>();


            return services;
        }
        public static IServiceCollection ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BddConnection");

            services.AddDbContext<PotShopIDbContext, PotShopDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());
            return services;
        }
    }
}
