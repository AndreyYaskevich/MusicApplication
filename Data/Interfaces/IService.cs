using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Services
{
    public interface IService<T> where T: class
    {
        void Add(T entity);
        void Add(List<T> entites);
        void Update(T entity);
    }
}
