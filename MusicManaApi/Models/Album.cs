using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MusicMana.Models;

public partial class Album
{
    [JsonPropertyName("album_id")]
    public int Id { get; set; }

    [JsonPropertyName("album_name")]
    public string AlbumName { get; set; } = null!;

    [JsonPropertyName("singer_id")]
    public long SingerId { get; set; }
}
