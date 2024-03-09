using System.ComponentModel.DataAnnotations;

namespace Model.Order
{
    public class AddOrder
    {



        [Required(ErrorMessage = "Veuillez entrer l'adresse de livraison")]
        public int AddressId { get; set; }

        [Required(ErrorMessage = "Veuillez entrer un Mode de paiement")]
        public string PaymentMethod { get; set; }          
    }
}
