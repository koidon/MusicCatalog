using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Models;
using MusicCatalog.Services.Spotify;

namespace MusicCatalog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISpotifyAccountService _spotifyAccountService;
    private readonly ISpotifyService _spotifyService;
    private readonly IConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger, ISpotifyAccountService spotifyAccountService, IConfiguration configuration, ISpotifyService spotifyService)
    {
        _logger = logger;
        _spotifyAccountService = spotifyAccountService;
        _configuration = configuration;
        _spotifyService = spotifyService;
    }

    public async Task<IActionResult> Index()
    {
        var playlist = await GetPlaylist();

        return View(playlist);
    }

    public async Task<IActionResult> Release(string songId)
    {
        var playlist = await GetPlaylist();

        ViewBag.SongId = songId;

        var song = playlist.FirstOrDefault(s => s.Id == songId);

        return View(song);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    private async Task<IEnumerable<Song>> GetPlaylist()
    {
        try
        {
            var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"], _configuration["Spotify:ClientSecret"]);

            var playlist = await _spotifyService.GetPlaylist("0AKGtks1OdL5kSnL6D9IdL",
                "tracks.items(track(name%2Cpopularity%2Cid%2Calbum(name%2Cid%2Cimages(url))%2Cartists(name%2Cid%2Cpopularity)))", token);

            return playlist;
        }
        catch (Exception e)
        {
            Debug.Write(e);

            return Enumerable.Empty<Song>();
        }
    }
}
