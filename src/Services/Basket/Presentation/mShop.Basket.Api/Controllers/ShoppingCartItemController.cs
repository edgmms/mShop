using Microsoft.AspNetCore.Mvc;
using mShop.Basket.Api.Infrastructure.Mapper.Extensions;
using mShop.Basket.Api.Models.ShoppingCart;
using mShop.Basket.Core.Domain;
using mShop.Basket.Services;
using mShop.Core.Results;
using System.Threading.Tasks;

namespace mShop.Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ShoppingCartItemController : ControllerBase
    {
        #region Fields

        private readonly IShoppingCartService _shoppingCartService;

        #endregion

        #region Ctor

        public ShoppingCartItemController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        #endregion
 
        #region Shopping Cart Item

        [HttpPost("{customerId}")]
        public virtual async Task<IActionResult> Post(int customerId, [FromBody] AddShoppingCartItemModel model)
        {
            var shoppingCartItem = model.ModelToEntity<ShoppingCartItem>();
            var updatedShoppingCart = await _shoppingCartService.InsertShoppingCartItem(shoppingCartItem, customerId, model.ShoppingCartType);
            var result = new SuccessDataResult(updatedShoppingCart);
            return Ok(result);
        }

        [HttpPut("{customerId}")]
        public virtual async Task<IActionResult> Put(int customerId, [FromBody] UpdateShoppingCartItemModel model)
        {
            var shoppingCartItem = model.ModelToEntity<ShoppingCartItem>();
            var updatedShoppingCart = await _shoppingCartService.UpdateShoppingCartItem(shoppingCartItem, customerId, model.ShoppingCartType);
            var result = new SuccessDataResult(updatedShoppingCart);
            return Ok(result);
        }

        [HttpDelete("{customerId}")]
        public virtual async Task<IActionResult> Delete(int customerId, [FromBody] DeleteShoppingCartItemModel model)
        {
            var updatedShoppingCart = await _shoppingCartService.DeleteShoppingCartItem(model.ProductId, customerId, model.ShoppingCartType);
            var result = new SuccessDataResult(updatedShoppingCart);
            return Ok(result);
        }

        #endregion
         
    }
}
