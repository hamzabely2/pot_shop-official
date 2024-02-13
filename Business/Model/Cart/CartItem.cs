using Model.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cart
{
    public class CartItem
    {
        public int Quantity { get; set; }
        public float? Subtotal { get; set; }
        public ReadItem Items { get; set; }
    }
}
