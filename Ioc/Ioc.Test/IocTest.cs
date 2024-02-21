using Context;
using Context.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interface.Item;
using Repository.Interface.Order;
using Repository.Interface.User;
using Repository.Item;
using Repository.Order;
using Repository.User;
using Service.Interface.Item;
using Service.Interface.Order;
using Service.Interface.User;
using Service.Item;
using Service.Order;
using Service.User;

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
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<RoleIRepository, RoleRepository>();
            services.AddScoped<RoleUserIRepository, RoleUserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IColorItemRepository, ColorItemRepository>();

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
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IDetailsItemService, DetailsItemService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICartService, CartService>();
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
