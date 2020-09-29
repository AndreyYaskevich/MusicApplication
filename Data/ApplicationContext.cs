using Microsoft.EntityFrameworkCore;
using MusicApplication.Data.Models;

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
                new Album { Id = 1, Title = "Album1", Price = 12.00M, },
                new Album { Id = 2, Title = "Album2", Price = 23.00M },
                new Album { Id = 3, Title = "Album3", Price = 10.00M });
            builder.Entity<Song>().HasData(
                new Song { Id = 1, AlbumId = 1, Name = "Song1" },
                new Song { Id = 2, AlbumId = 2, Name = "Song2" },
                new Song { Id = 3, AlbumId = 3, Name = "Song3" },
                new Song { Id = 4, AlbumId = 2, Name = "Song4" },
                new Song { Id = 5, AlbumId = 2, Name = "Song5" },
                new Song { Id = 6, AlbumId = 1, Name = "Song6" });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=musicstoredb; Trusted_Connection=True;");
        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
