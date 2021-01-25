namespace mShop.Catalog.Api.Models.Results
{
    public class ErrorDataResult : DataResult
    {
        public ErrorDataResult(object data, string message) : base(data, false, message)
        {
        }

        public ErrorDataResult(object data) : base(data, false)
        {
        }

        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
