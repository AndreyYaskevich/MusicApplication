using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MusicApplication.Models;
using MusicApplication.Services;

namespace MusicApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : Controller
    {
        private readonly IMusicRepository<Song> _repository;
        private readonly IService<Song> _service;
        public SongController(IMusicRepository<Song> repository, IService<Song> service)
        {
            _repository = repository;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Song> Get() => _repository.GetAll();
        //public IEnumerable<Song> Get() => _repository.GetAll(x => x.AlbumId == 1, x=> x.Album);

        [HttpGet]
        [Route("{id}")]
        public Song Get(int id) => _repository.GetById(id);

        [HttpPost]
        [Route("")]
        public void Add([FromBody] List<Song> songs) => _service.Add(songs);

        [HttpPut]
        public void Update(Song song) => _service.Update(song);

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id) => _repository.Delete(id);
    }
}
