using Microsoft.AspNetCore.Mvc;
using MusicApplication.Data.Interfaces;

namespace MusicApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("")]
        public void Create([FromBody] int[] cartItemIds) => _service.CreateOrder(cartItemIds, 1);
    }
}
