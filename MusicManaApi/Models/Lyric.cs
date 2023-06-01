using System;
using System.Collections.Generic;

namespace MusicMana.Models;

public partial class Lyric
{
    public long Id { get; set; }

    public string LyricUrl { get; set; } = null!;
}
