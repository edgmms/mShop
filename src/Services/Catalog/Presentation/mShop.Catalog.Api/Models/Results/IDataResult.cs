namespace mShop.Catalog.Api.Models.Results
{
    public interface IDataResult : IResult
    {
        object Data { get; set; }
    }
}
