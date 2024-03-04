using System.ComponentModel.DataAnnotations;

namespace Entity.Model
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        public int? ImageId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string? PhoneNumber { get; set; }
        public bool Deactivated { get; set; } 
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<RoleUser> Roles_Users { get; set; }
        public DateTime CreatedDate { get; set; }

        public DateTime UpdateDate { get; set; }
        public virtual ICollection<Cart> Cart { get; set; }

    }

}