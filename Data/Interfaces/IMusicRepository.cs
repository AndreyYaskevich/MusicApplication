using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicApplication
{
    public interface IMusicRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        
        T GetById(int id);
        Song GetLast();
        void Insert(T entity);
        void Delete(int id);
        void Update(T entity);
        void Save();
        
    }
}
