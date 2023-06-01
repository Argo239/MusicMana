using System;
using System.Collections.Generic;

namespace MusicMana.Models;

public partial class Singer
{
    public long Id { get; set; }

    public string Sname { get; set; } = null!;

    public string Area { get; set; } = null!;
}
