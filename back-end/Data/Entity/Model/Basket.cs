using System;
using System.Collections.Generic;

namespace Api.Data.Context.Model;

public partial class Basket
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public virtual ICollection<BasketItem> BasketItems { get; set; }
}
