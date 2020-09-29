using MusicApplication.Data.Interfaces;
using MusicApplication.Models;
using System;
using System.Collections.Generic;

namespace MusicApplication.Services
{
    public class AlbumService : IMusicService<Album>
    {
        private readonly IGenericRepository<Album> _repository;

        public AlbumService(IGenericRepository<Album> repository)
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
            var editModel = _repository.FindById(entity.Id);
            editModel.Title = entity.Title;
            editModel.Price = entity.Price;

            _repository.Update(editModel);
        }
    }
}