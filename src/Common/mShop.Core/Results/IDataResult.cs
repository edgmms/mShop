namespace mShop.Core.Results
{
    /// <summary>
    /// Defines the <see cref="IDataResult" />.
    /// </summary>
    public partial interface IDataResult : IResult
    {
        /// <summary>
        /// Gets or sets the Data.
        /// </summary>
        object Data { get; set; }
    }
}
