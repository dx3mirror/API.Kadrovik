using System;
using System.Collections.Generic;

namespace Infrastructure.Entity;

public partial class RequestSite
{
    public int Id { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public string? Email { get; set; }

    public string? About { get; set; }
}
