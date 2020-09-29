using System.Collections.Generic;

namespace MusicApplication.Services
{
    public interface IService<T> where T : class
    {
        void Add(T entity);
        void Add(List<T> entites);
        void Update(T entity);
    }
}
