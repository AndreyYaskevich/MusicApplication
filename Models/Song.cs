using MusicApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Models
{
    public class Song : IDataObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }

        public int? AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
