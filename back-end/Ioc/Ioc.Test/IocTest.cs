using Context;
using Context.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Interface;
using Service;
using Service.Interface;

namespace Ioc.Test
{
    public static class IocTest
    {
        /// <summary>
        /// Configure repository injection
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureInjectionDependencyRepositoryTest(this IServiceCollection services)
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


        /// <summary>
        /// Configure service injection
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureInjectionDependencyServiceTest(this IServiceCollection services)
        {
            services.AddScoped<IConnectionService, ConnectionService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAdressService, AdressService>();
            services.AddScoped<IDetailsItemService, DetailsItemService>();

            return services;
        }


        /// <summary>
        /// Configuring the in-memory database connection for the test environment
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection ConfigureDBContextTest(this IServiceCollection services)
        {
            services.AddDbContext<PotShopIDbContext, PotShopDbContext>(options =>
                options.UseInMemoryDatabase(databaseName: "TestApplication")
                );

            return services;
        }
    }
}
