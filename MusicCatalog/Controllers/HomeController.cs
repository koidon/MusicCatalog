using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MusicCatalog.Enums;
using MusicCatalog.Models;
using MusicCatalog.Services;
using MusicCatalog.Services.Spotify;
using Album = MusicCatalog.Models.Albums.Album;

namespace MusicCatalog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISpotifyAccountService _spotifyAccountService;
    private readonly ISpotifyService _spotifyService;
    private readonly IConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger, ISpotifyAccountService spotifyAccountService,
        IConfiguration configuration, ISpotifyService spotifyService)
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
        var song = await GetSong(songId);

        ViewBag.Alert = TempData["Alert"] ?? "";

        TempData["type"] = "song";

        return View(song);
    }

    public async Task<IActionResult> Album(string albumId)
    {
        var album = await GetAlbum(albumId);

        TempData["type"] = "album";

        ViewBag.Alert = TempData["Alert"] ?? "";

        return View(album);
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
            var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"],
                _configuration["Spotify:ClientSecret"]);

            var playlist = await _spotifyService.GetPlaylist("0AKGtks1OdL5kSnL6D9IdL",
                "tracks.items(track(name%2Cpopularity%2Cid%2Calbum(name%2Cid%2Cimages(url))%2Cartists(name%2Cid%2Cpopularity)))",
                token);

            return playlist;
        }
        catch (Exception e)
        {
            Debug.Write(e);
            ViewBag.Alert = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när låtarna skulle hämtas " + e.Message);

            return Enumerable.Empty<Song>();
        }
    }

    private async Task<Song> GetSong(string songId)
    {
        try
        {
            var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"],
                _configuration["Spotify:ClientSecret"]);

            var song = await _spotifyService.GetSongById(songId, token);

            return song;
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när låten skulle hämtas " + e.Message);

            return new Song();
        }
    }

    private async Task<Album> GetAlbum(string albumId)
    {
        try
        {
            var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"],
                _configuration["Spotify:ClientSecret"]);

            var album = await _spotifyService.GetAlbumById(albumId, token);

            return album;
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] = AlertService.ShowAlert(Alerts.Danger, "Något gick fel när Albumet skulle hämtas " + e.Message);

            return new Album();
        }
    }
}