using System.ComponentModel.DataAnnotations;

namespace Entity.Model;

public partial class Order
{
    [Key]
    public int Id { get; set; }
    public int UserId { get; set; } 
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public decimal TotalAmount { get; set; }
    public DateTime OrderDate { get; set; } 
    public string ShippingAddress { get; set; }
    public string BillingAddress { get; set; } 
    public string PaymentMethod { get; set; } 
    public string OrderStatus { get; set; }

    public Order()
    {
        OrderDate = DateTime.UtcNow;
    }
}
