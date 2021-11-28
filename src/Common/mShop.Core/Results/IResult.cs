namespace mShop.Core.Results
{
    /// <summary>
    /// Defines the <see cref="IResult" />.
    /// </summary>
    public partial interface IResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether Success.
        /// </summary>
        bool Success { get; set; }

        /// <summary>
        /// Gets or sets the Message.
        /// </summary>
        string Message { get; set; }
    }
}
