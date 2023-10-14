using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MusicCatalog.Models.Albums;
    [NotMapped]
    public class GetAlbum
    {
        [JsonPropertyName("album_type")]
        public string? AlbumType { get; set; }

        [JsonPropertyName("total_tracks")]
        public int TotalTracks { get; set; }

        [JsonPropertyName("available_markets")]
        public string[]? AvailableMarkets { get; set; }

        [JsonPropertyName("external_urls")]
        public ExternalUrls? ExternalUrls { get; set; }

        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("images")]
        public Images[]? Images { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("release_date")]
        public string? ReleaseDate { get; set; }

        [JsonPropertyName("release_date_precision")]
        public string? ReleaseDatePrecision { get; set; }

        [JsonPropertyName("restrictions")]
        public Restrictions? Restrictions { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        [JsonPropertyName("artists")]
        public Artists[]? Artists { get; set; }

        [JsonPropertyName("tracks")]
        public Tracks? Tracks { get; set; }

        [JsonPropertyName("copyrights")]
        public Copyrights[]? Copyrights { get; set; }

        [JsonPropertyName("external_ids")]
        public ExternalIds? ExternalIds { get; set; }

        [JsonPropertyName("genres")]
        public string[]? Genres { get; set; }

        [JsonPropertyName("label")]
        public string? Label { get; set; }

        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }
    }

    public class ExternalUrls
    {
        [JsonPropertyName("spotify")]
        public string? Spotify { get; set; }
    }

    public class Images
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }

    public class Restrictions
    {
        [JsonPropertyName("reason")]
        public string? Reason { get; set; }
    }

    public class Artists
    {
        [JsonPropertyName("external_urls")]
        public ExternalUrls1? ExternalUrls { get; set; }

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

    public class ExternalUrls1
    {
        [JsonPropertyName("spotify")]
        public string? Spotify { get; set; }
    }

    public class Tracks
    {
        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("next")]
        public string? Next { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("previous")]
        public string? Previous { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("items")]
        public Items[]? Items { get; set; }
    }

    public class Items
    {
        [JsonPropertyName("artists")]
        public Artists1[]? Artists { get; set; }

        [JsonPropertyName("available_markets")]
        public string[]? AvailableMarkets { get; set; }

        [JsonPropertyName("disc_number")]
        public int DiscNumber { get; set; }

        [JsonPropertyName("duration_ms")]
        public int DurationMs { get; set; }

        [JsonPropertyName("explicit")]
        public bool Explicit { get; set; }

        [JsonPropertyName("external_urls")]
        public ExternalUrls2? ExternalUrls { get; set; }

        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("is_playable")]
        public bool IsPlayable { get; set; }

        [JsonPropertyName("linked_from")]
        public LinkedFrom? LinkedFrom { get; set; }

        [JsonPropertyName("restrictions")]
        public Restrictions1? Restrictions { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("preview_url")]
        public string? PreviewUrl { get; set; }

        [JsonPropertyName("track_number")]
        public int TrackNumber { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }

        [JsonPropertyName("is_local")]
        public bool IsLocal { get; set; }
    }

    public class Artists1
    {
        [JsonPropertyName("external_urls")]
        public ExternalUrls3? ExternalUrls { get; set; }

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

    public class ExternalUrls3
    {
        [JsonPropertyName("spotify")]
        public string? Spotify { get; set; }
    }

    public class ExternalUrls2
    {
        [JsonPropertyName("spotify")]
        public string? Spotify { get; set; }
    }

    public class LinkedFrom
    {
        [JsonPropertyName("external_urls")]
        public ExternalUrls4? ExternalUrls { get; set; }

        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }
    }

    public class ExternalUrls4
    {
        [JsonPropertyName("spotify")]
        public string? Spotify { get; set; }
    }

    public class Restrictions1
    {
        [JsonPropertyName("reason")]
        public string? Reason { get; set; }
    }

    public class Copyrights
    {
        [JsonPropertyName("text")]
        public string? Text { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }

    public class ExternalIds
    {
        [JsonPropertyName("isrc")]
        public string? Isrc { get; set; }

        [JsonPropertyName("ean")]
        public string? Ean { get; set; }

    }
