using Microsoft.AspNetCore.Mvc;
using mShop.Core.Infrastructure;
using mShop.Core.Results;
using mShop.Discount.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mShop.Discount.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            var _couponService = EngineContext.Current.Resolve<ICouponService>();
            var coupon = _couponService.GetCouponById(id);
            var result = new SuccessDataResult(coupon);
            return Ok(result);
        }

        [HttpGet("ByProductId/{id}")]
        public virtual IActionResult GetByProductId(int id)
        {
            var _couponService = EngineContext.Current.Resolve<ICouponService>();
            var coupon = _couponService.GetCouponByProductId(id);
            var result = new SuccessDataResult(coupon);
            return Ok(result);
        }
    }
}
