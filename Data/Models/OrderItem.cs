using MusicApplication.Controllers;

namespace MusicApplication.Data.Models
{
    public class OrderItem : IEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
