namespace mShop.Core.Results
{
    public interface IResult
    {
        bool Success { get; set; }

        string Message { get; set; }
    }
}
