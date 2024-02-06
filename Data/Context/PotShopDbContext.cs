﻿using Context.Interface;
using Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Context
{
    public partial class PotShopDbContext : DbContext, PotShopIDbContext
    {
        public PotShopDbContext()
        {
        }

        public PotShopDbContext(DbContextOptions<PotShopDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adress> Adresses { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!; public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<ImageItem> ImagesItems { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<RoleUser> UsersRoles { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=potshop;uid=root", ServerVersion.Parse("5.7.36-mysql"));
        }

    }
}
