using MusicApplication.Data.Models;
using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Data.Interfaces
{
    public interface IShoppingCartService
    {
        IEnumerable<ShoppingCart> AddItemToCart(int amount, int albumId, int cartId);
    }
}
