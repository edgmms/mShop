namespace mShop.Core.Results
{
    /// <summary>
    /// Defines the <see cref="SuccessDataResult" />.
    /// </summary>
    public partial class SuccessDataResult : DataResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessDataResult"/> class.
        /// </summary>
        /// <param name="data">The data<see cref="object"/>.</param>
        /// <param name="message">The message<see cref="string"/>.</param>
        public SuccessDataResult(object data, string message) : base(data, true, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessDataResult"/> class.
        /// </summary>
        /// <param name="data">The data<see cref="object"/>.</param>
        public SuccessDataResult(object data) : base(data, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessDataResult"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public SuccessDataResult(string message) : base(default, true, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SuccessDataResult"/> class.
        /// </summary>
        public SuccessDataResult() : base(default, true)
        {
        }
    }
}
