
using System.ComponentModel.DataAnnotations;


namespace Model.User
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Veuillez entrer votre password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Veuillez entrer votre email")]
        public string? Email { get; set; }
    }
}
