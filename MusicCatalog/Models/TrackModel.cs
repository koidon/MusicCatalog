
namespace MusicCatalog.Models
{
    public class TrackModel{
        public string id { get; set; }
        public string name { get; set; }
        public int popularity { get; set; }
        public Album album { get; set; }
        public List<Artist> artists { get; set; }
            
    }
}