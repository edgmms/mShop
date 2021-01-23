using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mShop.Catalog.Api.Models.Catalog
{
    public class ProductSearchModel : BaseEntitySearchModel
    {
        public string ProductName { get; set; }
    }
}
