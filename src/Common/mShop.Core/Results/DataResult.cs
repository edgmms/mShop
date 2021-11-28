namespace mShop.Core.Results
{
    /// <summary>
    /// Defines the <see cref="DataResult" />.
    /// </summary>
    public partial class DataResult : Result, IDataResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataResult"/> class.
        /// </summary>
        /// <param name="data">The data<see cref="object"/>.</param>
        /// <param name="success">The success<see cref="bool"/>.</param>
        /// <param name="message">The message<see cref="string"/>.</param>
        public DataResult(object data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataResult"/> class.
        /// </summary>
        /// <param name="data">The data<see cref="object"/>.</param>
        /// <param name="success">The success<see cref="bool"/>.</param>
        public DataResult(object data, bool success) : base(success)
        {
            Data = data;
        }

        /// <summary>
        /// Gets or sets the Data.
        /// </summary>
        public object Data { get; set; }
    }
}
