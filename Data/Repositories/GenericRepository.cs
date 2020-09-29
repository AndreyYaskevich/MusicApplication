using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicApplication
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _entites;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _entites = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entites.ToList();
        }
        public IEnumerable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _entites;
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

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = _entites;
            if (includes.Any())
            {
                query = null;
                foreach (var include in includes)
                {
                    query = _entites.Include(include);
                }
            }
            return await query.Where(predicate).ToListAsync();
        }

        public TEntity FindById(int id)
        {
            return _entites.Find(id);
        }

        public void Insert(TEntity entity)
        {
            try
            {
                if (entity == null) throw new ArgumentNullException("entity");

                _entites.Add(entity);
                Save();
            }
            catch (DbEntityValidationException) { }
        }

        public void Update(TEntity entity)
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
            if (ent != null)
            {
                _entites.Remove(ent);
                Save();
            }

        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}