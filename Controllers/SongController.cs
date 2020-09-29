using Microsoft.AspNetCore.Mvc;
using MusicApplication.Data.Interfaces;
using MusicApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SongController : Controller
    {
        private readonly IGenericRepository<Song> _repository;
        private readonly IMusicService<Song> _service;
        public SongController(IGenericRepository<Song> repository, IMusicService<Song> service)
        {
            _repository = repository;
            _service = service;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IEnumerable<Song>> Get() => await _repository.GetAllAsync(x => x.AlbumId == 1, x => x.Album);
        //public IEnumerable<Song> Get() => _repository.GetAll(x => x.AlbumId == 1, x=> x.Album);

        [HttpGet]
        [Route("{id}")]
        public Song Get(int id) => _repository.FindById(id);

        [HttpPost]
        [Route("")]
        public void Add([FromBody] List<Song> songs) => _service.AddWithPrefix(songs);
        //public void Add([FromBody] Song song) => _service.AddWithPrefix(song);

        [HttpPut]
        public void Update(Song song) => _service.Update(song);

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id) => _repository.Delete(id);
    }
}
