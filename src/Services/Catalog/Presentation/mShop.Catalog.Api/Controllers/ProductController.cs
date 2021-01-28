using Microsoft.AspNetCore.Mvc;
using mShop.Catalog.Api.Infrastructure.Mapper.Extensions;
using mShop.Catalog.Api.Models.Catalog;
using mShop.Catalog.Api.Models.Messages;
using mShop.Catalog.Core.Domain.Catalog;
using mShop.Catalog.Services;
using mShop.Core.Infrastructure;
using mShop.Core.Results;
using System.Linq;
using System.Threading.Tasks;

namespace mShop.Catalog.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ProductController : ControllerBase
    {
        [HttpGet("Search")]
        public virtual IActionResult Get([FromQuery] ProductSearchModel model)
        {
            var _productService = EngineContext.Current.Resolve<IProductService>();

            var products = _productService.SearchProducts(model.ProductName, pageIndex: model.PageIndex,
                pageSize: model.PageSize, model.LoadOnlyTotalCount);

            var data = new ProductListModel
            {
                Data = products.Select(x =>
                {
                    return x.ToModel<ProductModel>();
                }),
                TotalCount = products.TotalCount, 
            };

            return Ok(data);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(string id)
        {
            var _productService = EngineContext.Current.Resolve<IProductService>();

            var product = await _productService.GetByIdAsync(id);

            var model = product.ToModel<ProductModel>();

            var result = new SuccessDataResult(model);
            return Ok(result);
        }

        [HttpPost("Create")]
        public virtual async Task<IActionResult> Post([FromBody] ProductModel model)
        {
            if (!ModelState.IsValid)
            {
                var errorResult = new ErrorResult(ErrorMessage.ModelStateInvalid);
                return BadRequest(errorResult);
            }

            var product = model.ToEntity<Product>();

            var _productService = EngineContext.Current.Resolve<IProductService>();

            await _productService.InsertAsync(product);

            var result = new SuccessResult(SuccessMessage.ProductInserted);

            return Ok(result);
        }

        [HttpPut("Update")]
        public virtual async Task<IActionResult> Put([FromBody] ProductModel model)
        {
            var _productService = EngineContext.Current.Resolve<IProductService>();

            var product = await _productService.GetByIdAsync(model.Id);

            product = model.ToEntity(product);

            await _productService.UpdateAsync(product);

            var result = new SuccessResult(SuccessMessage.ProductUpdated);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(string id)
        {
            var _productService = EngineContext.Current.Resolve<IProductService>();

            await _productService.DeleteByIdAsync(id);

            var result = new SuccessResult(SuccessMessage.ProductDeleted);

            return Ok(result);
        }
    }
}
