using MusicApplication.Services;
using System.Collections.Generic;

namespace MusicApplication.Data.Interfaces
{
    public interface IMusicService<T> : IService<T> where T : class
    {
        void AddWithPrefix(T entity);
        void AddWithPrefix(List<T> entites);
    }
}
