using MusicApplication.Controllers;
using MusicApplication.Models;
using System.Collections.Generic;

namespace MusicApplication.Data.Models
{
    public class ShoppingCart : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
        public ShoppingCart()
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
        }
    }
}
