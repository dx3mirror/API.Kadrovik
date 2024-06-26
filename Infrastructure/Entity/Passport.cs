﻿using System;
using System.Collections.Generic;

namespace Infrastructure.Entity;

public partial class Passport
{
    public int Id { get; set; }

    public int? FkSotrudnik { get; set; }

    public string? NomerPasporta { get; set; }

    public DateTime? Datavidachi { get; set; }

    public DateTime? DataregistrachiiPoMestu { get; set; }

    public string? Vidan { get; set; }

    public string? AdressjitelstvaPopasportu { get; set; }

    public string? AressFakticheskiy { get; set; }
}
