using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using MusicCatalog.Enums;
using MusicCatalog.Models;
using MusicCatalog.Models.Artist;
using MusicCatalog.Services;
using MusicCatalog.Services.Reviews;
using MusicCatalog.Services.Spotify;
using MusicCatalog.ViewModels;
using Album = MusicCatalog.Models.Albums.Album;

namespace MusicCatalog.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISpotifyAccountService _spotifyAccountService;
    private readonly ISpotifyService _spotifyService;
    private readonly IConfiguration _configuration;
    private readonly IReviewService _reviewService;
    private readonly IMemoryCache _memoryCache;

    public HomeController(ILogger<HomeController> logger, ISpotifyAccountService spotifyAccountService,
        IConfiguration configuration, ISpotifyService spotifyService, IReviewService reviewService, IMemoryCache memoryCache)
    {
        _logger = logger;
        _spotifyAccountService = spotifyAccountService;
        _configuration = configuration;
        _spotifyService = spotifyService;
        _reviewService = reviewService;
        _memoryCache = memoryCache;
    }

    public async Task<IActionResult> Index(string searchQuery, string sortOrder)
    {
        var playlist = await GetPlaylist();


        if (!string.IsNullOrEmpty(searchQuery))
        {
            searchQuery = searchQuery.ToLower();
            playlist = playlist.Where(s =>
                s.Artists?.ToLower() == searchQuery ||
                s.AlbumName?.ToLower() == searchQuery ||
                s.TrackName?.ToLower() == searchQuery
            ).ToList();
        }

        playlist = sortOrder switch
        {
            "release" => playlist.OrderByDescending(s => s.ReleaseDate).ToList(),
            "popularity" => playlist.OrderByDescending(s => s.Popularity).ToList(),
            _ => playlist
        };

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

    public async Task<IActionResult> Artist(string artistId)
    {
        var artist = await GetArtist(artistId);
        var artistAlbums = await GetArtistAlbums(artistId);
        var viewModel = new ArtistAlbumsViewModel
        {
            Artist = artist,
            ArtistAlbums = artistAlbums,
            ReviewCount = new List<int>()
        };

        if (!_memoryCache.TryGetValue("ReviewCounts", out List<int>? cachedReviewCounts))
        {
            cachedReviewCounts = new List<int>();

            if (artistAlbums.Albums is not null)
            {
                foreach (var album in artistAlbums.Albums)
                {
                    var count = await _reviewService.GetReviewCount(album.Id ?? "");
                    cachedReviewCounts.Add(count);
                }
            }

            _memoryCache.Set("ReviewCounts", cachedReviewCounts, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
            });
        }

        viewModel.ReviewCount = cachedReviewCounts;

        return View(viewModel);
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
            ViewBag.Alert =
                AlertService.ShowAlert(Alerts.Danger, "Något gick fel när låtarna skulle hämtas " + e.Message);

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
            TempData["Alert"] =
                AlertService.ShowAlert(Alerts.Danger, "Något gick fel när låten skulle hämtas " + e.Message);

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
            TempData["Alert"] =
                AlertService.ShowAlert(Alerts.Danger, "Något gick fel när Albumet skulle hämtas " + e.Message);

            return new Album();
        }
    }

    private async Task<Artist> GetArtist(string artistId)
    {
        try
        {
            var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"],
                _configuration["Spotify:ClientSecret"]);

            var artist = await _spotifyService.GetArtistById(artistId, token);

            return artist;
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] =
                AlertService.ShowAlert(Alerts.Danger, "Något gick fel när Artisten skulle hämtas " + e.Message);

            return new Artist();
        }
    }

    private async Task<ArtistAlbums> GetArtistAlbums(string artistId)
    {
        try
        {
            var token = await _spotifyAccountService.GetToken(_configuration["Spotify:ClientId"],
                _configuration["Spotify:ClientSecret"]);

            var artistAlbums = await _spotifyService.GetArtistAlbumsById(artistId, token);

            return artistAlbums;
        }
        catch (Exception e)
        {
            Debug.Write(e);
            TempData["Alert"] =
                AlertService.ShowAlert(Alerts.Danger, "Något gick fel när Artisten skulle hämtas " + e.Message);

            return new ArtistAlbums();
        }
    }
}