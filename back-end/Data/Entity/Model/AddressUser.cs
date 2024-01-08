using System;
using System.Collections.Generic;

namespace Api.Data.Context.Model;

public partial class AddressUser
{
    public int Id { get; set; }

    //cles etrange
    public string? UserId  { get; set; }
    public int AddresseId { get; set; }
}
