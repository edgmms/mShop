using RabbitMQ.Client;

namespace mShop.EventBus
{
    /// <summary>
    /// Defines the <see cref="IRabbitMQConnection" />.
    /// </summary>
    public partial interface IRabbitMQConnection
    {
        /// <summary>
        /// Gets a value indicating whether IsConnected.
        /// </summary>
        bool IsConnected { get; }

        /// <summary>
        /// The TryConnect.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        bool TryConnect();

        /// <summary>
        /// The CreateModel.
        /// </summary>
        /// <returns>The <see cref="IModel"/>.</returns>
        IModel CreateModel();
    }
}
