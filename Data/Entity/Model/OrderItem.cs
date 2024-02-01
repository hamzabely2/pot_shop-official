using System.ComponentModel.DataAnnotations;

namespace Entity.Model;

public partial class OrderItem
{
    [Key]
    public int Id { get; set; }
    public Item Item { get; set; }
    public int Quantity { get; set; }
    public decimal Subtotal { get; set; }
}
