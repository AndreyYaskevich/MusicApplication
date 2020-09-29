using MusicApplication.Data.Interfaces;
using MusicApplication.Data.Models;
using MusicApplication.Models;

namespace MusicApplication.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IGenericRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IGenericRepository<ShoppingCartItem> _shoppingCartItemRepository;
        public UserService(
            IGenericRepository<User> userRepository,
            IGenericRepository<ShoppingCart> shoppingCartRepository,
            IGenericRepository<ShoppingCartItem> shoppingCartItemRepository)
        {
            _userRepository = userRepository;
            _shoppingCartRepository = shoppingCartRepository;
            _shoppingCartItemRepository = shoppingCartItemRepository;
        }

        public void AddUser(User user)
        {
            _userRepository.Insert(user);
            var lastUser = _userRepository.FindById(user.Id);
            _shoppingCartRepository.Insert(new ShoppingCart { UserId = lastUser.Id });
        }

        public void DeleteUser(int id)
        {
            var cart = _shoppingCartRepository.FindById(id);
            _userRepository.Delete(id);

            _shoppingCartRepository.Delete(cart.Id);
        }
    }
}
