using MusicApplication.Data.Interfaces;
using MusicApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace MusicApplication.Services
{
    public class SongService : IMusicService<Song>
    {
        private readonly IGenericRepository<Song> _repository;
        public SongService(IGenericRepository<Song> repository)
        {
            _repository = repository;
        }

        public void Add(Song entity)
        {
            _repository.Insert(entity);
        }

        public void Add(List<Song> entites)
        {
            foreach (var entity in entites)
            {
                _repository.Insert(entity);
            }
        }

        public void AddWithPrefix(Song entity)
        {
            _repository.Insert(entity);
            var lastSong = _repository.GetAll().Last();
            lastSong.Name = $"{lastSong.Id}.{lastSong.Name}";
            _repository.Update(lastSong);
        }

        public void AddWithPrefix(List<Song> entites)
        {
            foreach (var entity in entites)
            {
                _repository.Insert(entity);
                var lastSong = _repository.GetAll().Last();
                lastSong.Name = $"{lastSong.Id}.{lastSong.Name}";
                _repository.Update(lastSong);
            }
        }

        public void Update(Song entity)
        {
            var editModel = _repository.FindById(entity.Id);
            editModel.Name = entity.Name;
            _repository.Update(editModel);
        }
    }
}