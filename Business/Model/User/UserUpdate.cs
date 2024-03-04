using System.ComponentModel.DataAnnotations;

namespace Model.User
{
    public class UserUpdate
    {
        [Required(ErrorMessage = "Veuillez entrer votre nom")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Veuillez entrer votre prenom")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Veuillez entrer votre email")]
        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public int? ImageId { get; set; }

        public bool Deactivated { get; set; }

        public int Id { get; set; }


    }
}
