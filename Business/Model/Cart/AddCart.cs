using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cart
{
    public class AddCart
    {
        [Required(ErrorMessage = "insérez la item")]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "insérez la quantita")]
        public int Quantity { get; set; }
    }
}
