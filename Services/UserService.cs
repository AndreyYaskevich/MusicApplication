using Microsoft.AspNetCore.Mvc.ApplicationModels;
using MusicApplication.Data.Interfaces;
using MusicApplication.Data.Models;
using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Services
{
    public class UserService : IService<User>
    {
        private readonly IMusicRepository<User> _repository;
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public UserService(IMusicRepository<User> repository, IShoppingCartRepository shoppingCartRepository)
        {
            _repository = repository;
            _shoppingCartRepository = shoppingCartRepository;
        }

        public void Add(User user)
        {
            _repository.Insert(user);
            var lastUser = _repository.GetById(user.Id);
            _shoppingCartRepository.Create(new ShoppingCart { UserId = lastUser.Id, TotalAmount = 0 });
        }

        public void Add(List<User> entites)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
