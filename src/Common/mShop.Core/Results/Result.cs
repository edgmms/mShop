namespace mShop.Core.Results
{
    /// <summary>
    /// Defines the <see cref="Result" />.
    /// </summary>
    public partial class Result : IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="success">The success<see cref="bool"/>.</param>
        /// <param name="message">The message<see cref="string"/>.</param>
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Result"/> class.
        /// </summary>
        /// <param name="success">The success<see cref="bool"/>.</param>
        public Result(bool success)
        {
            Success = success;
        }

        /// <summary>
        /// Gets or sets a value indicating whether Success.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the Message.
        /// </summary>
        public string Message { get; set; }
    }
}
