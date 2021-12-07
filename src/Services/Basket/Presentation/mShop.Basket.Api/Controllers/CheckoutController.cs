using Microsoft.AspNetCore.Mvc;
using mShop.Basket.Api.Infrastructure.Mapper.Extensions;
using mShop.Basket.Api.Models.Checkout;
using mShop.Basket.Core.Domain;
using mShop.Basket.Services;
using mShop.Core.Results;
using mShop.EventBus.Events.Basket.Checkout;
using mShop.EventBus.Producer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mShop.Basket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CheckoutController : ControllerBase
    {
        #region Fields

        private readonly IShoppingCartService _shoppingCartService;
        private readonly RabbitMQProducer _rabbitMQProducer;

        #endregion

        #region Ctor

        public CheckoutController(IShoppingCartService shoppingCartService,
            RabbitMQProducer rabbitMQProducer)
        {
            _shoppingCartService = shoppingCartService;
            _rabbitMQProducer = rabbitMQProducer;
        }

        #endregion

        #region Checkout
      
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CheckoutModel model)
        {
            var shoppingCart = await _shoppingCartService.GetShoppingCart(model.CustomerId, ShoppingCartType.ShoppingCart);
            if (shoppingCart == null)
                return BadRequest(new ErrorResult());

            var checkoutEvent = model.ModelToEvent<CheckoutEvent>();
            // get total price of shopping cart
            checkoutEvent.TotalPrice = shoppingCart.ShoppingCartItems.Sum(x => x.TotalPriceInclTax);

            var shoppingCartRemoved = await _shoppingCartService.DeleteShoppingCart(model.CustomerId, ShoppingCartType.ShoppingCart);
            if (!shoppingCartRemoved)
                return BadRequest(new ErrorResult());

            //send checkout event to rabbitmq
            _rabbitMQProducer.Publish(CheckoutEventDefaults.BasketCheckoutQueue, checkoutEvent);

            return Ok(new SuccessResult());
        }

        #endregion
    }
}
