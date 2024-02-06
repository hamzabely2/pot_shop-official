using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model
{
    public partial class Cart
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; } = 0;
        public float? Subtotal { get; set; } = 0;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public virtual Item Items { get; set; }     
    }
}