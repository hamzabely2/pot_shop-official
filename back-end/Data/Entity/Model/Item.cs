using System;
using System.Collections.Generic;

namespace Api.Data.Context.Model;

public partial class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public float? Price { get; set; }
    public bool? Stock { get; set; }
    public string Description { get; set; } = null!;
    public string Image { get; set; } = null!;
    public int? Category_Id { get; set; }
    public int? Color_Id { get; set; }
    public int? Material_Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
    public virtual ICollection<BasketItem> Baskets_Items { get; set; }
    public virtual ICollection<Comment>? Comments { get; set; }
    public virtual ICollection<OrderItem> Orders_Items { get; set; }
    public virtual Color? Color { get; set; } = null!;
    public virtual Material? Material { get; set; } = null!;
    public virtual Category? Category { get; set; } = null!;


}
