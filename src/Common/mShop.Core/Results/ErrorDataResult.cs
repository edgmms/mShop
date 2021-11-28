namespace mShop.Core.Results
{
    /// <summary>
    /// Defines the <see cref="ErrorDataResult" />.
    /// </summary>
    public partial class ErrorDataResult : DataResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorDataResult"/> class.
        /// </summary>
        /// <param name="data">The data<see cref="object"/>.</param>
        /// <param name="message">The message<see cref="string"/>.</param>
        public ErrorDataResult(object data, string message) : base(data, false, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorDataResult"/> class.
        /// </summary>
        /// <param name="data">The data<see cref="object"/>.</param>
        public ErrorDataResult(object data) : base(data, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorDataResult"/> class.
        /// </summary>
        /// <param name="message">The message<see cref="string"/>.</param>
        public ErrorDataResult(string message) : base(default, false, message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ErrorDataResult"/> class.
        /// </summary>
        public ErrorDataResult() : base(default, false)
        {
        }
    }
}
