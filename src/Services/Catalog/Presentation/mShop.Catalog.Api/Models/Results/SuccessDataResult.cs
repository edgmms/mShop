using System;
using System.Collections.Generic;
using System.Text;

namespace mShop.Catalog.Api.Models.Results
{
    public class SuccessDataResult : DataResult 
    {
        public SuccessDataResult(object data, string message) : base(data, true, message)
        {
        }

        public SuccessDataResult(object data) : base(data, true)
        {
        }

        public SuccessDataResult(string message) : base(default, true, message)
        {

        }

        public SuccessDataResult() : base(default, true)
        {

        }
    }
}
