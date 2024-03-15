using System.ComponentModel.DataAnnotations;

namespace Entity.Model;

public partial class Order
{
    [Key]
    public int UserId { get; set; }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    public float? TotalAmount { get; set; }
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string Street { get; set; } = null!;
    public int? Code { get; set; } = 0!;
    public string PaymentMethod { get; set; }
    public string OrderStatus { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
