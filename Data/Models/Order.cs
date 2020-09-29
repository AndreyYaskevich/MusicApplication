using MusicApplication.Controllers;
using System.Collections.Generic;

namespace MusicApplication.Data.Models
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public decimal Amount { get; set; }
    }
}
