using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MusicCatalog.Models;
[NotMapped]

public class GetSong
 {
        [JsonPropertyName("album")]
        public Album? Album { get; set; }

        [JsonPropertyName("artists")]
        public Artists[]? Artists { get; set; }

        [JsonPropertyName("available_markets")]
        public object[]? AvailableMarkets { get; set; }

        [JsonPropertyName("disc_number")]
        public int DiscNumber { get; set; }

        [JsonPropertyName("duration_ms")]
        public int DurationMs { get; set; }

        [JsonPropertyName("external_ids")]
        public ExternalIds? ExternalIds { get; set; }

        [JsonPropertyName("external_urls")]
        public ExternalUrls? ExternalUrls { get; set; }

        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("id")]
        public required string Id { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }

        [JsonPropertyName("preview_url")]
        public object? PreviewUrl { get; set; }

        [JsonPropertyName("track_number")]
        public int TrackNumber { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        [JsonPropertyName("is_local")]
        public bool IsLocal { get; set; }
    }

    public partial class Album
    {
        [JsonPropertyName("album_type")]
        public string? AlbumType { get; set; }

        [JsonPropertyName("total_tracks")]
        public int TotalTracks { get; set; }

        [JsonPropertyName("available_markets")]
        public object[]? AvailableMarkets { get; set; }

        [JsonPropertyName("external_urls")]
        public ExternalUrls1? ExternalUrls { get; set; }

        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("release_date")]
        public string? ReleaseDate { get; set; }

        [JsonPropertyName("release_date_precision")]
        public string? ReleaseDatePrecision { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        [JsonPropertyName("artists")]
        public Artists1[]? Artists { get; set; }
    }

    public class ExternalUrls1
    {
        [JsonPropertyName("spotify")]
        public string? Spotify { get; set; }
    }

    public class Artists1
    {
        [JsonPropertyName("external_urls")]
        public ExternalUrls2? ExternalUrls { get; set; }

        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }
    }

    public class ExternalUrls2
    {
        [JsonPropertyName("spotify")]
        public string? Spotify { get; set; }
    }

    public partial class Artists
    {
        [JsonPropertyName("external_urls")]
        public ExternalUrls3? ExternalUrls { get; set; }

        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }
    }

    public class ExternalUrls3
    {
        [JsonPropertyName("spotify")]
        public string? Spotify { get; set; }
    }

    public class ExternalIds
    {
        [JsonPropertyName("isrc")]
        public string? Isrc { get; set; }
    }

    public class ExternalUrls
    {
        [JsonPropertyName("spotify")]
        public string? Spotify { get; set; }
    }