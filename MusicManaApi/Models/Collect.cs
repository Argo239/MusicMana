using System;
using System.Collections.Generic;

namespace MusicMana.Models;

public partial class Collect
{
    public long Id { get; set; }

    public long FavoritesId { get; set; }

    public long MusicId { get; set; }

    public DateTime FavoritesDate { get; set; }

    public long CoState { get; set; }
}
