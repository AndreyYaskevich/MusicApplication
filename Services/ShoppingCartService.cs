using MusicApplication.Data.Interfaces;
using MusicApplication.Data.Models;
using MusicApplication.Models;
namespace MusicApplication.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IGenericRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IGenericRepository<Album> _albumRepository;
        private readonly IGenericRepository<ShoppingCartItem> _shoppingCartItemRepository;
        public ShoppingCartService(
            IGenericRepository<ShoppingCart> shoppingCartRepository,
            IGenericRepository<Album> albumRepository,
            IGenericRepository<ShoppingCartItem> shoppingCartItemRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _albumRepository = albumRepository;
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public void AddItemToCart(int cartId, int albumId, int quantity)
        {
            var cart = _shoppingCartRepository.FindById(cartId);
            var item = _albumRepository.FindById(albumId);
            cart.ShoppingCartItems.Add(new ShoppingCartItem { AlbumId = albumId, Quantity = quantity });
            _shoppingCartRepository.Update(cart);

        }

        public void RemoveItemFromCart(int cartId, int albumId)
        {
            var cart = _shoppingCartRepository.FindById(cartId);
            var item = _shoppingCartItemRepository.FindById(albumId);
            cart.ShoppingCartItems.Remove(item);
            _shoppingCartItemRepository.Save();
        }
    }
}
