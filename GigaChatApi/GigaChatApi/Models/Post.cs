using Redis.OM.Modeling;

namespace GigaChatApi.Models
{
    [Document(StorageType = StorageType.Json, Prefixes = new []{"Post"})]
    public class Post
    {
        [RedisIdField]
        public Ulid Id { get; set; }

        [Indexed]
        public Guid AuthorId { get; set; }

        public string? Text { get; set; }
        public string AuthorName { get; set; }

        [Indexed]
        public GeoLoc Location { get; set; }
    }
}
