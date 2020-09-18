using MusicApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Data.Interfaces
{
    public interface IMusicService<T> : IService<T>  where T : class
    {
        void AddWithPrefix(T entity);
        void AddWithPrefix(List<T> entites);
    }
}
