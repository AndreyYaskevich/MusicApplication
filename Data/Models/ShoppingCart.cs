using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace MusicApplication.Data.Models
{
    public class ShoppingCart
    {
        
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public User User { get; set; }
        public List<Album> Albums { get; set; }
        public ShoppingCart()
        {
            Albums = new List<Album>();
        }
    }
}
