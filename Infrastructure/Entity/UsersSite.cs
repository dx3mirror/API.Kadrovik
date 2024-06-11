using System;
using System.Collections.Generic;

namespace Infrastructure.Entity;

public partial class UsersSite
{
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }
}
