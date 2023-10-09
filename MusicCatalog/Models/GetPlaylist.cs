﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MusicCatalog.Models;
[NotMapped]
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
    public string id { get; set; }
    public string name { get; set; }
    public int popularity { get; set; }
}

public partial class Album
{
    public string id { get; set; }
    public Images[] images { get; set; }
    public string name { get; set; }
}

public class Images
{
    public string url { get; set; }
    public int height { get; set; }
    public int width { get; set; }
}

public partial class Artists
{
    public string id { get; set; }
    public string name { get; set; }
}
