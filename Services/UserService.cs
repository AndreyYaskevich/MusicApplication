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
        private readonly IMusicRepository<Cart> _cartRepository;

        public UserService(IMusicRepository<User> repository, IMusicRepository<Cart> cartRepository)
        {
            _repository = repository;
            _cartRepository = cartRepository;
        }

        public void Add(User user)
        {
            _repository.Insert(user);
            _cartRepository.Insert(new Cart() { UserId = user.Id});
        }

        public void Add(List<User> entites)
        {
            throw new NotImplementedException();
        }

        public void AddWithPrefix(User entity)
        {
            throw new NotImplementedException();
        }

        public void AddWithPrefix(List<User> entites)
        {
            throw new NotImplementedException();
        }

        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
