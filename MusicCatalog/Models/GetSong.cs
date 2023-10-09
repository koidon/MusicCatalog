namespace MusicCatalog.Models;

public class GetSong
{
    public Album album { get; set; }
    public Artists[] artists { get; set; }
    public object[] available_markets { get; set; }
    public int disc_number { get; set; }
    public int duration_ms { get; set; }
    public External_ids external_ids { get; set; }
    public External_urls external_urls { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public int popularity { get; set; }
    public object preview_url { get; set; }
    public int track_number { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
    public bool is_local { get; set; }
}

public partial class Album
{
    public string album_type { get; set; }
    public int total_tracks { get; set; }
    public object[] available_markets { get; set; }
    public External_urls1 external_urls { get; set; }
    public string href { get; set; }
    public string release_date { get; set; }
    public string release_date_precision { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
    public Artists1[] artists { get; set; }
}

public class External_urls1
{
    public string spotify { get; set; }
}



public class Artists1
{
    public External_urls2 external_urls { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
}

public class External_urls2
{
    public string spotify { get; set; }
}

public partial class Artists
{
    public External_urls3 external_urls { get; set; }
    public string href { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
}

public class External_urls3
{
    public string spotify { get; set; }
}

public class External_ids
{
    public string isrc { get; set; }
}

public class External_urls
{
    public string spotify { get; set; }
}