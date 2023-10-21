using System.ComponentModel.DataAnnotations;

namespace MusicCatalog.Dtos.Post;

    public class UpdatePostDto
    {
        public int Id { get; set; }
        
        public int CommunityId { get; set; }

        public string Title { get; set; } = null!;

        [Required (ErrorMessage = "Rutan får inte lämnas tom")]
        [MaxLength(3000, ErrorMessage = "Texten får  inte vara längre än 3000 karaktärer")]
        public string Content { get; set; } = null!;
    }
