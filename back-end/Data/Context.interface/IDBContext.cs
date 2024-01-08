
using Microsoft.EntityFrameworkCore;

using Api.Data.Context.Model;
using Microsoft.AspNetCore.Identity;

namespace Api.Data.Context.Contract
{
    public interface IDBContext : IDB
    {
        DbSet<Item> Items { get; set; }
        DbSet<Basket> Baskets { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Address> Addresses { get; set; }
        DbSet<AddressUser> Addresses_Users { get; set; }   
        DbSet<BasketItem> Baskets_Items { get; set; }
        DbSet<Color> Colors { get; set; }
        DbSet<Comment> Comments { get; set; }   
        DbSet<Category> Categories { get; set; }
        DbSet<OrderItem> Orders_Items { get; set; }
        DbSet<Material> Materials { get; set; }
    }
}
