using System;
using System.Collections.Generic;

namespace Api.Data.Context.Model;

public partial class Comment
{
    public int Id { get; set; }
    public string Content { get; set; } = null!;
    //cles etrange
    public int Item_Id { get; set; }
    public string UserId { get; set; } = null!;
    public virtual Item Item { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime UpdateDate { get; set; }
}
