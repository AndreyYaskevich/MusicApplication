using MusicApplication.Data.Interfaces;
using MusicApplication.Data.Models;
using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicApplication.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IGenericRepository<OrderItem> _orderItemRepository;
        private readonly IGenericRepository<ShoppingCartItem> _shoppingCartItemRepository;
        private readonly IGenericRepository<Album> _albumRepository;
        private readonly IGenericRepository<User> _userRepository;

        public OrderService(
            IGenericRepository<ShoppingCart> shoppingCartRepository,
            IGenericRepository<Order> orderRepository,
            IGenericRepository<OrderItem> orderItemRepository,
            IGenericRepository<ShoppingCartItem> shoppingCartItemRepository,
            IGenericRepository<Album> albumRepository,
            IGenericRepository<User> userRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _orderRepository = orderRepository;
            _orderItemRepository = orderItemRepository;
            _shoppingCartItemRepository = shoppingCartItemRepository;
            _albumRepository = albumRepository;
            _userRepository = userRepository;
        }
        public void CreateOrder(int[] cartItemIds, int userId)
        {
            //no catched exceptions for null shoppingcartitems
            IEnumerable<ShoppingCartItem> orderedItems = _shoppingCartItemRepository.GetAll();

            var orderedItemsIds =
                orderedItems
                .Where(t => cartItemIds.Contains(t.Id))
                .Select(t => t.AlbumId)
                .ToArray();

            var albums = _albumRepository.GetAll();

            var amounts = albums
                .Where(t => orderedItemsIds.Contains(t.Id))
                .Select(t => t.Price).ToList();

            var amount = 0M;

            foreach (var item in amounts)
            {
                amount += item;
            }

            _orderRepository.Insert(new Order { Amount = amount, UserId = userId });

            foreach (var itemId in cartItemIds)
            {
                _shoppingCartItemRepository.Delete(itemId);
            }

            var message = new StringBuilder();
            var user = _userRepository.FindById(userId);
            message.Append($"Hi, Mr. {user.Name}!\nThanks for your order!");

            EmailService.SendEmail(user.Email, "Asp.Net Music Application", message.ToString());
        }
    }
}
