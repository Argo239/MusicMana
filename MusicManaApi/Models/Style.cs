using System;
using System.Collections.Generic;

namespace MusicMana.Models;

public partial class Style
{
    public long Id { get; set; }

    public string MusicStyle { get; set; } = null!;
}
