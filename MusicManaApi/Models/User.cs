using System;
using System.Collections.Generic;

namespace MusicMana.Models;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string? UserPass { get; set; }

    public string? UserSex { get; set; }

    public string? UserEmail { get; set; }

    public long UserStateId { get; set; }

    public long UserLevel { get; set; }
}
