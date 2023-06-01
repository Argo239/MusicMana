using System;
using System.Collections.Generic;

namespace MusicMana.Models;

public partial class Favorite
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public DateTime CreateDate { get; set; }

    public string? Description { get; set; }

    public string FaName { get; set; } = null!;

    public long FaState { get; set; }
}
