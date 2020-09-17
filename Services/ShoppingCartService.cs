﻿using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using MusicApplication.Data.Models;
using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Services
{
    public class ShoppingCartService : IDisposable
    {
        private ApplicationContext _context;
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        private ShoppingCartService(ApplicationContext context)
        {
            _context = context;
        }

        public static ShoppingCartService GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<ApplicationContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCartService(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Album album, int amount)
        {
            _context.ShoppingCartItems.Add(
                new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Album = album,
                    Amount = amount
                });
            _context.SaveChanges();
        }

        public List<ShoppingCartItem> GetCartItems()
        {
            return ShoppingCartItems ??
                (ShoppingCartItems =
                _context.ShoppingCartItems
                .Where(s => s.ShoppingCartId == ShoppingCartId)
                .Include(s => s.Album)
                .ToList());
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }
    }
}
