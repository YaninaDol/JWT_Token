using System;
using System.Collections.Generic;

namespace JWT_Token.Models;

public partial class ListProduct
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int? UserId { get; set; }

    public string? Status { get; set; }
}
