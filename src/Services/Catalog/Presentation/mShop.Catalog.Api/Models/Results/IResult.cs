using System;
using System.Collections.Generic;
using System.Text;

namespace mShop.Catalog.Api.Models.Results
{
    public interface IResult
    {
        bool Success { get; set; }

        string Message { get; set; }
    }
}
