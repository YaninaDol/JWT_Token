using System;
using System.Collections.Generic;

namespace JWT_Token.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Parol { get; set; }
}
