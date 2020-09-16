using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApplication.Models
{
    public class ApplicationContext : DbContext
    {
        
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Album>().HasData(
                new Album
                {
                    Id = 1,
                    Name = "Album1"
                },
                new Album
                {
                    Id = 2,
                    Name = "Album2"
                });
            builder.Entity<Song>().HasData(
                new Song
                {
                    Id = 1,
                    AlbumId = 1,
                    Name = "Song1",
                    Author="Author1",
                },
                new Song
                {
                    Id = 2,
                    AlbumId = 2,
                    Name = "Song2",
                    Author = "Author2"
                });
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=musicstoredb; Trusted_Connection=True;");
        }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
    }
}
