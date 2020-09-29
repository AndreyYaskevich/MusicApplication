using MusicApplication.Controllers;
using System;
using System.Collections.Generic;

namespace MusicApplication.Models
{
    public class Album : IEntity
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Duration { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public string LogoPath { get; set; }
        public ICollection<Song> Songs { get; set; }
        public Album()
        {
            Songs = new List<Song>();
        }

    }
}
