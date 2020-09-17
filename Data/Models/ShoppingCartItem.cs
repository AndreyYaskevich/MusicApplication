using MusicApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Data.Models
{
    public class ShoppingCartItem
    {
        public string ItemId { get; set; }
        public Album Album { get; set; }
        public int AlbumId { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
