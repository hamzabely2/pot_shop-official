using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Context.Interface
{
    public interface PotShopIDbContext : IDb
    {        
        DbSet<Address> Addresses { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<ColorItem> ColorsItems { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<Item> Items { get; set; }
        DbSet<Material> Materials { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<RoleUser> UsersRoles { get; set; }

    }
}
