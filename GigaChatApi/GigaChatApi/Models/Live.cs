using Redis.OM.Modeling;

namespace GigaChatApi.Models
{
    public class Live
    {

        public int Id { get; set; }


        [Indexed]
        public GeoLoc loc { get; set; }


    }
}
