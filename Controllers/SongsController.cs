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
    public class SongsController : Controller
    {
        private readonly IMusicRepository<Song> _repository;
        private readonly ISongService _service;
        public SongsController(IMusicRepository<Song> context, ISongService service)
        {
            _repository = context;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Song> Get() => _repository.GetAll(x => x.AlbumId == 1, x=> x.Album);

        [HttpGet]
        [Route("{id}")]
        public Song Get(int id) => _repository.GetById(id);

        [HttpPost]
        [Route("")]
        public void AddSong([FromBody] List<Song> songs) => _service.AddSongsWithPrefix(songs);

        
        [HttpPut]
        public void Update(Song song)
        {
            var editModel = _repository.GetById(song.Id);
            editModel.Name = song.Name;
            editModel.Author = song.Author;
            _repository.Update(editModel);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id) => _repository.Delete(id);
    }
}
