using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicApplication.Models;

namespace MusicApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : Controller
    {
        private readonly IMusicRepository<Album> _repository;
        public AlbumsController(IMusicRepository<Album> context)
        {
            _repository = context;
        }

        [HttpGet]
        //public IEnumerable<Album> Get() => _repository.GetAll();
        
        [HttpGet]
        [Route("{id}")]
        public Album Get(int id) => _repository.GetById(id);

        [HttpPost]
        [Route("")]
        public void AddAlbum([FromBody] Album album) => _repository.Insert(album);

        [HttpPut]
        public void Update(Album album)
        {
            var editModel = _repository.GetById(album.Id);
            editModel.Name = album.Name;
            editModel.Songs = album.Songs;
            _repository.Update(editModel);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete(int id) => _repository.Delete(id); 
    }
}
