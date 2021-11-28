namespace mShop.Core.Results
{
    /// <summary>
    /// Defines the <see cref="ErrorResult" />.
    /// </summary>
    public partial class ErrorResult : Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResult"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public ErrorResult(string message) : base(false, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorResult"/> class.
        /// </summary>
        public ErrorResult() : base(false)
        {
        }
    }
}
