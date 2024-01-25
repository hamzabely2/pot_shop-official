
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
            services.AddScoped<IConnectionService, ConnectionService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAdressService, AdressService>();
            services.AddScoped<IDetailsItemService, DetailsItemService>();

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
