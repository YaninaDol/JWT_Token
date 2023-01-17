using System;
using System.Collections.Generic;

namespace JWT_Token.Models;

public partial class History
{
    public int Id { get; set; }

    public string Date { get; set; } = null!;

    public int? ListId { get; set; }
}
