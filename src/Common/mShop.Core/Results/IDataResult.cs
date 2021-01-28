namespace mShop.Core.Results
{
    public interface IDataResult : IResult
    {
        object Data { get; set; }
    }
}
