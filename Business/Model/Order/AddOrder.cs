using System.ComponentModel.DataAnnotations;

namespace Model.Order
{
    public class AddOrder
    {
        [Required(ErrorMessage = "Veuillez entrer l'adresse de livraison")]
        public string ShippingAddress { get; set; }

        [Required(ErrorMessage = "Veuillez entrer l'Adresse de facturation")]
        public string BillingAddress { get; set; }

        [Required(ErrorMessage = "Veuillez entrer un Mode de paiement")]
        public string PaymentMethod { get; set; }          
    }
}
