using Context.Interface;
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
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Material> Materials { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<RoleUser> UsersRoles { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Label = "Tagine", Description = "Tagine description" },
                new Category { Id = 2, Label = "Pot de conservation", Description = "Pot de conservation description" },
                new Category { Id = 3, Label = "Pot de jardin", Description = "Pot de jardin description" }
            );

            modelBuilder.Entity<Material>().HasData(
              new Material { Id = 1, Label = "Argile rouge", Description = "L’argile rouge de type illite est une argile très absorbante et adsorbante. Sa couleur apportée par sa richesse en oxyde de fer lui confère des propriétés matifiante, révélatrice de bonne mine mais aussi circulatoire et décongestionnante. Elle sera idéale pour les peaux couperosées et sujettes aux rougeurs. En masque, l'argile rouge ravive les peaux ternes et redonne force et éclat à une chevelure foncée. Pour des utilisations en argilothérapie, on se limitera à un usage par voie externe en cataplasme. Nom INCI : Illite et Kaolin. Origine : France." },
              new Material { Id = 2, Label = "Argile blanche", Description = "Argile blanche description" },
              new Material { Id = 4, Label = "Argile chamottée", Description = "Argile chamottée description" },
              new Material { Id = 5, Label = "Argile noire", Description = "Argile noire description" },
              new Material { Id = 6, Label = "Argile grès", Description = "Argile grès description" }
          );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=potshop;uid=root", ServerVersion.Parse("5.7.36-mysql"));
        }

    }
}
