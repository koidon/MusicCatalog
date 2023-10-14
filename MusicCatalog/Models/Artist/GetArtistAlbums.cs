using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MusicCatalog.Models.Artist;

    [NotMapped]
    public class GetArtistAlbums
    {
        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("limit")]
        public int? Limit { get; set; }

        [JsonPropertyName("next")]
        public string? Next { get; set; }

        [JsonPropertyName("offset")]
        public int? Offset { get; set; }

        [JsonPropertyName("previous")]
        public string? Previous { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }

        [JsonPropertyName("items")]
        public Items[]? Items { get; set; }
    }

    public class Items
    {
        [JsonPropertyName("album_type")]
        public string? AlbumType { get; set; }

        [JsonPropertyName("total_tracks")]
        public int? TotalTracks { get; set; }

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

        [JsonPropertyName("album_group")]
        public string? AlbumGroup { get; set; }
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
        public int? Height { get; set; }

        [JsonPropertyName("width")]
        public int? Width { get; set; }
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
