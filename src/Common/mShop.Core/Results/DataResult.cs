namespace mShop.Core.Results
{
    public class DataResult : Result, IDataResult
    {
        public DataResult(object data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        public DataResult(object data, bool success) : base(success)
        {
            Data = data;
        }

        public object Data { get; set; }
    }
}
