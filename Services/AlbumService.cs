using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Services
{
    public class AlbumService: IService<Album> 
    {
        private readonly IMusicRepository<Album> _repository;

        public AlbumService(IMusicRepository<Album> repository)
        {
            _repository = repository;
        }

        public void Add(Album album)
        {
            _repository.Insert(album);
        }
        public void Add(List<Album> albums)
        {
            foreach (var album in albums)
            {
                _repository.Insert(album);
            }
        }

        public void AddWithPrefix(Album entity)
        {
            throw new NotImplementedException();
        }

        public void AddWithPrefix(List<Album> entites)
        {
            throw new NotImplementedException();
        }

        public void Update(Album entity)
        {
            var editModel = _repository.GetById(entity.Id);
            editModel.Name = entity.Name;
            editModel.Name = entity.Name;
            editModel.Price = entity.Price;
            _repository.Update(editModel);
        }
    }
}