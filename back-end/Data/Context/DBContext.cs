using System;
using System.Collections.Generic;
using Api.Data.Context.Contract;
using Api.Data.Context.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Api.Data.Context;

public partial class DBContext : IdentityDbContext<User>, IDBContext
{
    public DBContext()
    {
    }
    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AddressUser> Addresses_Users { get; set; }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<BasketItem> Baskets_Items { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Color> Colors { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Material> Materials { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> Orders_Items { get; set; }

    public virtual DbSet<User> Users { get; set; }

 /*   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("server=localhost;database=potshop;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.36-mysql"));
    }
*/

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<User>().ToTable("Users");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRole"); 
        builder.Ignore<IdentityUserLogin<string>>();
        builder.Ignore<IdentityUserToken<string>>();
        builder.Ignore<IdentityUserClaim<string>>();
        builder.Ignore<IdentityRoleClaim<string>>();
}
}
