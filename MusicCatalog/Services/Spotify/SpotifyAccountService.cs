﻿using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using MusicCatalog.Models;

namespace MusicCatalog.Services.Spotify;

public class SpotifyAccountService : ISpotifyAccountService
{
    private readonly HttpClient _httpClient;

    public SpotifyAccountService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetToken(string? clientId, string? clientSecret)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, "token");

        request.Headers.Authorization = new AuthenticationHeaderValue(
            "Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{clientId}:{clientSecret}")));

        request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            { "grant_type", "client_credentials" }
        });

        var response = await _httpClient.SendAsync(request);

        response.EnsureSuccessStatusCode();

        await using var responseStream = await response.Content.ReadAsStreamAsync();
        var authResult = await JsonSerializer.DeserializeAsync<AuthResult>(responseStream);

        return authResult?.AccessToken ?? throw new InvalidOperationException("Access token not found in the response");
    }
}