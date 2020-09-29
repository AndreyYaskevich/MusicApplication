using MusicApplication.Controllers;
using MusicApplication.Data.Models;

namespace MusicApplication.Models
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}
