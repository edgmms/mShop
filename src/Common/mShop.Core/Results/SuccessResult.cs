namespace mShop.Core.Results
{
    /// <summary>
    /// Defines the <see cref="SuccessResult" />.
    /// </summary>
    public partial class SuccessResult : Result
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessResult"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public SuccessResult(string message) : base(true, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessResult"/> class.
        /// </summary>
        public SuccessResult() : base(true)
        {
        }
    }
}
