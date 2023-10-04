namespace MusicCatalog.Models
{
    public class TrackModel{
        public TrackModel() {}

        public string Id { get; set; }
        public string Name { get; set; }
        public int Popularity { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}