using System.Net.Http.Headers;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MusicCatalog.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly HttpClient client = new HttpClient();
        private readonly IConfiguration _configuration;

        public PlaylistController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET
        [HttpGet("playlist/{playlistId}")]
        public async Task<IActionResult> FetchPlaylist()
        {
            try
            {
                string playlistId = "37i9dQZF1DXcecv7ESbOPu?si=791688b7c7644d80";
                var clientId = _configuration.GetValue<string>("ClientId");
                var clientSecret = _configuration.GetValue<string>("ClientSecret");

                // Prepare the request body with clientId and clientSecret
                var requestBody = new StringBuilder();
                requestBody.Append("grant_type=client_credentials");
                requestBody.Append($"&client_id={Uri.EscapeDataString(clientId)}");
                requestBody.Append($"&client_secret={Uri.EscapeDataString(clientSecret)}");

                // Set the content type header to application/x-www-form-urlencoded
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Send the POST request to obtain the access token
                var tokenResponse = await client.PostAsync("https://accounts.spotify.com/api/token", new StringContent(requestBody.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded"));

                tokenResponse.EnsureSuccessStatusCode();
                var tokenContent = await tokenResponse.Content.ReadAsStringAsync();

                // Parse the JSON response to get the access token
                var tokenObj = JObject.Parse(tokenContent);
                var accessToken = tokenObj.GetValue("access_token").ToString();

                // Use the access token in subsequent requests
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                // Now you can use the access token to make requests to the Spotify API

                using HttpResponseMessage response =
                    await client.GetAsync($"https://api.spotify.com/v1/playlists/{playlistId}");

                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine(responseBody);
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Exception caught" + e.Message);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}