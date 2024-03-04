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

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Color> Colors { get; set; } = null!;
        public virtual DbSet<ColorItem> ColorsItems { get; set; } = null!;
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

            modelBuilder.Entity<Color>().HasData(
               new Color { Id = 1, Label = "Rouge", Hex = "#FF0000" },
               new Color { Id = 2, Label = "Bleu", Hex = "#0046FF" },
               new Color { Id = 3, Label = "Vert", Hex = "#13FF00 " },
               new Color { Id = 4, Label = "Orange", Hex = "#FFC300" }
            );

            modelBuilder.Entity<Role>().HasData(
              new Role { Id = 1, Name = "User" },
              new Role { Id = 2, Name = "Admin" },
              new Role { Id = 3, Name = "SuperAdmin" }
           );

            modelBuilder.Entity<Material>().HasData(
              new Material { Id = 1, Label = "Argile rouge", Description = "L’argile rouge de type illite est une argile très absorbante et adsorbante. Sa couleur apportée par sa richesse en oxyde de fer lui confère des propriétés matifiante, révélatrice de bonne mine mais aussi circulatoire et décongestionnante. Elle sera idéale pour les peaux couperosées et sujettes aux rougeurs. En masque, l'argile rouge ravive les peaux ternes et redonne force et éclat à une chevelure foncée. Pour des utilisations en argilothérapie, on se limitera à un usage par voie externe en cataplasme. Nom INCI : Illite et Kaolin. Origine : France." },
              new Material { Id = 2, Label = "Argile blanche", Description = "L'argile à modeler blanche « Terra 92 » présente l'avantage d'être non toxique et varie du blanc à la couleur crème quand la température de cuisson augmente." },
              new Material { Id = 5, Label = "Argile noire", Description = "En sol sableux, un compost de cette argile permet de retenir l'eau, de fixer les particules et d'absorber au mieux les nutriments. L'argile blanche participe également au pralinage pour la plantation ou la transplantation d'arbres fruitiers, arbustes à baie et vignes" },
              new Material { Id = 6, Label = "Argile grès", Description = "Le grès est une argile haute température : sa température de cuisson doit être supérieure à 1200°C. Imperméable, résistante au gel et aux éraflures et disposant d'une très grande dureté, la terre de grès pour poterie est idéale pour la céramique utilitaire et extérieure." }
          );
        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=localhost;database=potshop;uid=root", ServerVersion.Parse("5.7.36-mysql"));
        }*/

    }
}
