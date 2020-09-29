using Microsoft.AspNetCore.Mvc;
using MusicApplication.Data.Interfaces;
using MusicApplication.Models;
using System.Collections.Generic;

namespace MusicApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly IGenericRepository<User> _repository;
        public UserController(IGenericRepository<User> repository, IUserService service)
        {
            _service = service;
            _repository = repository;
        }
        [HttpGet]
        public IEnumerable<User> Get() => _repository.GetAll();

        [HttpPost]
        [Route("")]
        public void Add([FromBody] User user) => _service.AddUser(user);


        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id) => _service.DeleteUser(id);
    }
}