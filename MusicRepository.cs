using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MusicApplication.Models;
using Sitecore.FakeDb;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MusicApplication
{
    public class MusicRepository<T> : IMusicRepository<T> where T: class
    {
        private ApplicationContext _context;
        private DbSet<T> _entites;
        public MusicRepository(ApplicationContext context)
        {
            _context = context;
            _entites = context.Set<T>();

        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable <T> query = null;
            foreach (var include in includes)
            {
                query = _entites.Include(include);
            }
            return query.Where(predicate) ?? _entites;
        }

        public T GetById(int id)
        {
            return _entites.Find(id);
        }

        
        public void Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _entites.Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                _context.SaveChanges();
            }
            catch (DbEntityValidationException) { }
        }
        public void Delete(int id)
        {
            var ent = _entites.Find(id);
            _entites.Remove(ent);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Song GetLast()
        {
            var songs = _context.Songs;
            var latestId = songs.Max(x => x.Id);
            return songs.Find(latestId);
        }

    }
}