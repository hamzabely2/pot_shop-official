using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public class Cart
    {
        public int Id { get; set; } 

        public int UserId { get; set; }

        public int ItemId { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }

        public List<CartItem> Items { get; set; } = new List<CartItem>();
    }
}
