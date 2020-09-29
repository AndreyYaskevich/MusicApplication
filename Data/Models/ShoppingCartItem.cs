using MusicApplication.Controllers;

namespace MusicApplication.Data.Models
{
    public class ShoppingCartItem : IEntity
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }
    }
}
