using System;
using System.Collections.Generic;
using System.Text;

namespace mShop.Catalog.Api.Models.Results
{
    public interface IDataResult : IResult
    {
        object Data { get; set; }
    }
}
