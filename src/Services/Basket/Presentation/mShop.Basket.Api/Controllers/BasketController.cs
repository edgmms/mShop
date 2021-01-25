using Microsoft.AspNetCore.Mvc;
using mShop.Basket.Core.Domain;
using mShop.Basket.Services;
using System.Threading.Tasks;

namespace mShop.Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class BasketController : ControllerBase
    {
        private readonly IShoppingCartService _shoppingCartService;

        public BasketController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        [HttpGet("{customerId}")]
        public virtual async Task<IActionResult> Get(int customerId, ShoppingCartType shoppingCartType)
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCart(customerId, shoppingCartType);
            return Ok(shoppingCart);
        }

        [HttpPost("{customerId}")]
        public virtual async Task<IActionResult> Put(int customerId, [FromBody] ShoppingCart shoppingCart)
        {
            var updatedShoppingCart = await _shoppingCartService.UpdateShoppingCart(shoppingCart, customerId);
            return Ok(updatedShoppingCart);
        }

        [HttpDelete("{customerId}")]
        public virtual async Task<IActionResult> Delete(int customerId, ShoppingCartType shoppingCartType)
        {
            var isDeleted = await _shoppingCartService.DeleteShoppingCart(customerId, shoppingCartType);
            return Ok(isDeleted);
        }

    }
}
