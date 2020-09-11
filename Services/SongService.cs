using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Services
{
    public class SongService : ISongService
    {
        private readonly IMusicRepository<Song> _repository;
        public SongService(IMusicRepository<Song> repository)
        {
            _repository = repository;
        }
        public void AddSongsWithPrefix(List<Song> songs)
        {
           
            foreach (var song in songs)
            {
                _repository.Insert(song);
                var lastSong = _repository.GetLast();
                lastSong.Name = $"{lastSong.Id}.{lastSong.Name}";
                _repository.Update(lastSong);
            }
        }

    }
}