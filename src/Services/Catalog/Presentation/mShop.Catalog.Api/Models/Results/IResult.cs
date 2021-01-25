namespace mShop.Catalog.Api.Models.Results
{
    public interface IResult
    {
        bool Success { get; set; }

        string Message { get; set; }
    }
}
