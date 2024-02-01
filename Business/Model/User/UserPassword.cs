using System.ComponentModel.DataAnnotations;


namespace Model.User
{
    public class UserPassword
    {
        [Required(ErrorMessage = "Veuillez entrez l'ancien mot de passe")]
        public string? OldPassword { get; set; }

        [Required(ErrorMessage = "Veuillez entrer votre nouvelle mot de passe")]
        public string? NewPassword { get; set; }

        [Required(ErrorMessage = "Veuillez remettre votre nouvelle mot de passe ")]
        public string? ConfirmNewPassword { get; set; }
    }
}
