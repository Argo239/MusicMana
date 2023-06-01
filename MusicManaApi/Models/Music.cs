using System;
using System.Collections.Generic;

namespace MusicMana.Models;

public partial class Music
{
    public long Id { get; set; }

    public string MusicName { get; set; } = null!;

    public long MusicSingerId { get; set; }

    public long MusicUrlId { get; set; }

    public long MusicStyleId { get; set; }

    public long LyricId { get; set; }

    public long AlbumId { get; set; }

    public long StateId { get; set; }
}
