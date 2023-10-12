using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MusicCatalog.Models;
[NotMapped]
public class GetPlaylist
{

    [JsonPropertyName("tracks")]
    public Tracks? Tracks { get; set; }
}

public class Tracks
{
    [JsonPropertyName("items")]
    public Items[]? Items { get; set; }
}

public class Items
{
    [JsonPropertyName("track")]
    public Track? Track { get; set; }
}

public class Track
{
    [JsonPropertyName("album")]
    public Album? Album { get; set; }

    [JsonPropertyName("artists")]
    public Artists[]? Artists { get; set; }

    [JsonPropertyName("id")]
    public required string Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("popularity")]
    public required int Popularity { get; set; }
}

public partial class Album
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("images")]
    public Images[]? Images { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }
}

public class Images
{
    [JsonPropertyName("url")]
    public required string Url { get; set; }

    [JsonPropertyName("height")]
    public int Height { get; set; }

    [JsonPropertyName("width")]
    public int Width { get; set; }
}

public partial class Artists
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }
}

