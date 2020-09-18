using MusicApplication.Data.Interfaces;
using MusicApplication.Data.Models;
using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IMusicRepository<Album> _albumRepository;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository, IMusicRepository<Album> albumRepository)
        {
            _albumRepository = albumRepository;
            _shoppingCartRepository = shoppingCartRepository;
        }
        public IEnumerable<ShoppingCart> AddItemToCart(int amount, int albumId, int cartId )
        {
            var cart = _shoppingCartRepository.GetShoppingCartById(cartId);
            var album = _albumRepository.GetById(albumId);
            cart.Albums.Add(album);
            cart.TotalAmount += album.Price * amount;
            _shoppingCartRepository.Update(cart);

            return _shoppingCartRepository.GetShoppingCartItems().Where(x => x.Id == cartId);
        }
    }
}
