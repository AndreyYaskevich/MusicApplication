using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Services
{
    public interface ISongService
    {
        void AddSongsWithPrefix(List<Song> songs);
    }
}
