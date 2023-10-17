using System.Text.Json.Serialization;

namespace MusicCatalog.Models.Artist
{
    public class GetArtist
    {
        [JsonPropertyName("external_urls")]
        public ExternalUrls? ExternalUrls{ get; set; }

        [JsonPropertyName("followers")]
        public Followers? Followers { get; set; }

        [JsonPropertyName("genres")]
        public string[]? Genres { get; set; }

        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("images")]
        public Images[]? Images { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("popularity")]
        public int? Popularity { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("uri")]
        public string? Uri { get; set; }
    }

    public class Followers
    {
        [JsonPropertyName("href")]
        public string? Href { get; set; }

        [JsonPropertyName("total")]
        public int? Total { get; set; }
    }
}