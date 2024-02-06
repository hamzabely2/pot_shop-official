using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Cart
{
    public class CartItem
    {
        public float? Subtotal { get; set; }
        public Entity.Model.Item Items { get; set; }
    }
}
