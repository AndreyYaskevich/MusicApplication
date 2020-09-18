using MusicApplication.Data.Interfaces;
using MusicApplication.Data.Models;
using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MusicApplication.Data.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationContext _context;

        public ShoppingCartRepository(ApplicationContext context)
        {
            _context = context;
        }
        
        public void Create(ShoppingCart cart)
        {
            _context.ShoppingCarts.Add(cart);
            Save();
        }
        public void Update(ShoppingCart cart)
        {
            try
            {
                if (cart == null)
                {
                    throw new ArgumentNullException("entity");
                }
                Save();
            }
            catch (DbEntityValidationException) { }
        }

        public ShoppingCart GetShoppingCartById(int id)
        {
            return _context.ShoppingCarts.Find(id);
        }

        public IEnumerable<ShoppingCart> GetShoppingCartItems()
        {
            return _context.ShoppingCarts.Include(x => x.Albums).ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
