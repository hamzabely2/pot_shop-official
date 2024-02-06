using Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Order
{
    public class ReadOrder
    {
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public float TotalAmount { get; set; } = 0;
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
