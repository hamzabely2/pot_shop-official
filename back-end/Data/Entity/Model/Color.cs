using System;
using System.Collections.Generic;

namespace Api.Data.Context.Model;

public partial class Color
{
    public Color()
    {
        Items = new HashSet<Item>();
    }
    public int Id { get; set; }
    public string Label { get; set; } = null!;
    public virtual ICollection<Item> Items { get; set; }
}
