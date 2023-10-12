using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MusicCatalog.Models;
[NotMapped]
public class AuthResult
{
    [JsonPropertyName("access_token")]
    public string? AccessToken { get; set; }

    [JsonPropertyName("tokenType")]
    public string? TokenType { get; set; }

    [JsonPropertyName("expires_in")]
    public int? ExpiresIn { get; set; }
}