using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MusicApplication.Models;
using Sitecore.FakeDb;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;

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

        public IEnumerable<T> GetAll()
        {
            return _entites.ToList();
        }
        public IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entites;
            if (includes.Length != 0)
            {
                query = null;
                foreach (var include in includes)
                {
                    query = _entites.Include(include);
                }
            }
            return query.ToList();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _entites;
            if (includes.Any())
            {
                query = null;
                foreach (var include in includes)
                {
                    query = _entites.Include(include);
                }
            }
            return query.Where(predicate).ToList();
        }

        public T GetById(int id)
        {
            return _entites.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null) throw new ArgumentNullException("entity");

                _entites.Add(entity);
                Save();
            }
            catch (DbEntityValidationException dbEx) { }
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

            Save();
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