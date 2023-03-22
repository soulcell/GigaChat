using Redis.OM.Modeling;

namespace GigaChatApi.Models
{
    [Document(StorageType = StorageType.Json, Prefixes = new []{"Post"})]
    public class Post
    {
        [Indexed]
        public int Id { get; set; }

        [Indexed]
        public Guid AuthorId { get; set; }
        
        public string? Text { get; set; }

        [Indexed]
        public GeoLoc Location { get; set; }
    }
}
