using System;
using System.Collections.Generic;

namespace Infrastructure.Entity;

public partial class User
{
    public int Id { get; set; }

    public byte[]? Login { get; set; }

    public byte[]? Password { get; set; }

    public int? Acces { get; set; }
}
