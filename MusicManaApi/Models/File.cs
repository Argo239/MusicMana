using System;
using System.Collections.Generic;

namespace MusicMana.Models;

public partial class File
{
    public long Id { get; set; }

    public string FileName { get; set; } = null!;

    public string FileUrl { get; set; } = null!;
}
