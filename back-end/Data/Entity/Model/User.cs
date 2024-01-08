using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Api.Data.Context.Model;

public partial class User : IdentityUser
{
    public string? LastName { get; set; }
    public virtual ICollection<Basket> Baskets { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
    public virtual ICollection<AddressUser> AddressUsers { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
