using System.ComponentModel.DataAnnotations;

namespace Model.Adress
{
    public class AdressAdd
    {

        [Required(ErrorMessage = "insérez la Ville")]
        public string City { get; set; } = null!;

        [Required(ErrorMessage = "insérez l'États")]
        public string State { get; set; } = null!;

        [Required(ErrorMessage = "insérez la Rue")]
        public string Street { get; set; } = null!;

        [Required(ErrorMessage = "insérez un code postal")]
        public int? Code { get; set; }
    }
}
