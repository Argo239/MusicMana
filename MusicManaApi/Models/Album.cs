using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MusicMana.Models;

namespace MusicMana.Models;

public partial class Album
{
    public int Id { get; set; }

    public string AlbumName { get; set; } = null!;

    public long SingerId { get; set; }

    public virtual Singer Singer { get; set; }
}
