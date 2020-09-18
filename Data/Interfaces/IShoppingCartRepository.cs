using MusicApplication.Data.Models;
using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Data.Interfaces
{
    public interface IShoppingCartRepository
    {
        IEnumerable<ShoppingCart> GetShoppingCartItems();
        
        void Create(ShoppingCart cart);
        ShoppingCart GetShoppingCartById(int id);
        void Update(ShoppingCart cart);

    }
}
