namespace MusicCatalog.Models;

public class GetPlaylist
{
    public Tracks tracks { get; set; }
}

public class Tracks
{
    public Items[] items { get; set; }
}

public class Items
{
    public Track track { get; set; }
}

public class Track
{
    public Album album { get; set; }
    public Artists[] artists { get; set; }
    public string name { get; set; }
    public int popularity { get; set; }
}

public class Album
{
    public Images[] images { get; set; }
    public string name { get; set; }
}

public class Images
{
    public string url { get; set; }
    public int height { get; set; }
    public int width { get; set; }
}

public class Artists
{
    public string name { get; set; }
}

