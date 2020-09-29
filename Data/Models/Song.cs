using MusicApplication.Controllers;

namespace MusicApplication.Models
{
    public class Song : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
