﻿using System;
using System.Collections.Generic;

namespace Infrastructure.Entity;

public partial class AdditionalDocument
{
    public int Id { get; set; }

    public string? FkSotrudnik { get; set; }

    public string? Snils { get; set; }

    public string? Polis { get; set; }

    public string? Inn { get; set; }

    public string? Kpp { get; set; }

    public string? TrudKnijka { get; set; }

    public string? MedKnikjka { get; set; }
}
