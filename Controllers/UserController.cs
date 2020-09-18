using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicApplication.Data.Interfaces;
using MusicApplication.Models;
using MusicApplication.Services;

namespace MusicApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IService<User> _service;
        private readonly IMusicRepository<User> _repository;
        public UserController(IMusicRepository<User> repository, IService<User> service)
        {
            _service = service;
            _repository = repository;
        }
        [HttpGet]
        public IEnumerable<User> Get() => _repository.GetAll();

        [HttpPost]
        [Route("")]
        public void Add([FromBody] User user) => _service.Add(user);


        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id) => _repository.Delete(id);
    }
}
