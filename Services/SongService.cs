using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicApplication.Services
{
    public class SongService : IService<Song>
    {
        private readonly IMusicRepository<Song> _repository;
        public SongService(IMusicRepository<Song> repository)
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
            var lastSong = _repository.GetLast();
            lastSong.Name = $"{lastSong.Id}.{lastSong.Name}";
            _repository.Update(lastSong);
        }

        public void AddWithPrefix(List<Song> entites)
        {
            foreach (var entity in entites)
            {
                _repository.Insert(entity);
                var lastSong = _repository.GetLast();
                lastSong.Name = $"{lastSong.Id}.{lastSong.Name}";
                _repository.Update(lastSong);
            }
        }

        public void Update(Song entity)
        {
            var editModel = _repository.GetById(entity.Id);
            editModel.Name = entity.Name;
            editModel.Author = entity.Author;
            _repository.Update(editModel);
        }
    }
}