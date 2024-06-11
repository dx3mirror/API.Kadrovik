using System;
using System.Collections.Generic;

namespace Infrastructure.Entity;

public partial class DocumentRezyme
{
    public int Id { get; set; }

    public byte[]? Doucment { get; set; }

    public string? Nazvaniy { get; set; }
}
