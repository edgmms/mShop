using Microsoft.AspNetCore.Mvc;
using mShop.Basket.Api.Models.Checkout;
using mShop.Basket.Core.Domain;
using mShop.Basket.Services;
using System.Net;
using System.Threading.Tasks;
using mShop.Basket.Api.Infrastructure.Mapper.Extensions;
using mShop.EventBus.Events.Basket.Checkout;
using System;
using System.Linq;
using mShop.EventBus.Producer;
using mShop.Basket.Api.Models.ShoppingCart;
using mShop.Core.Results;

namespace mShop.Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ShoppingCartController : ControllerBase
    {
        #region Fields

        private readonly IShoppingCartService _shoppingCartService;

        #endregion

        #region Ctor

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        #endregion

        #region Shopping Cart

        [HttpGet("{customerId}")]
        public virtual async Task<IActionResult> Get(int customerId, ShoppingCartType shoppingCartType)
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCart(customerId, shoppingCartType);
            var result = new SuccessDataResult(shoppingCart);
            return Ok(result);
        }

        [HttpDelete("{customerId}")]
        public virtual async Task<IActionResult> Delete(int customerId, [FromBody] DeleteShoppingCartModel model)
        {
            var isDeleted = await _shoppingCartService.DeleteShoppingCart(customerId, (ShoppingCartType)model.ShoppingCartTypeId);
            var result = new Result(isDeleted);
            return Ok(result);
        }

        #endregion




    }
}
