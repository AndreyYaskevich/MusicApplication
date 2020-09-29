using Microsoft.AspNetCore.Mvc;
using MusicApplication.Data.Interfaces;

namespace MusicApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartService _service;

        public ShoppingCartController(IShoppingCartService service)
        {
            _service = service;
        }

        [HttpPost]
        public void Add()
        {
            //add random items to carts

            _service.AddItemToCart(2, 2, 2);
            _service.AddItemToCart(1, 1, 2);
            _service.AddItemToCart(1, 3, 1);
        }

        [HttpDelete]
        public void Delete() => _service.RemoveItemFromCart(1, 2);
    }
}
