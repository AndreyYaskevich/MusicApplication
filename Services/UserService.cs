using Microsoft.AspNetCore.Mvc.ApplicationModels;
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

        public UserService(IMusicRepository<User> repository)
        {
            _repository = repository;
        }

        public void Add(User user)
        {
            _repository.Insert(user);

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
