using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApplication.Models;
using MusicApplication.Services;

namespace MusicApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : Controller
    {
        private readonly IMusicRepository<Album> _repository;
        private readonly IService<Album> _service;
        public AlbumsController(IMusicRepository<Album> repository, IService<Album> service)
        {
            _repository = repository;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Album> Get() => _repository.GetAll();
        
        [HttpGet]
        [Route("{id}")]
        public Album Get(int id) => _repository.GetById(id);

        [HttpPost]
        [Route("")]
        public void Add([FromBody] List<Album> albums) => _service.Add(albums);

        [HttpPut]
        public void Update(Album album) => _service.Update(album);
        
        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id) => _repository.Delete(id); 
    }
}
