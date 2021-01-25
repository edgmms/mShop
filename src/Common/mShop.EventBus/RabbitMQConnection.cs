using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Threading;

namespace mShop.EventBus
{
    /// <summary>
    /// Defines the <see cref="RabbitMQConnection" />.
    /// </summary>
    public partial class RabbitMQConnection : IRabbitMQConnection
    {
        /// <summary>
        /// Defines the _connectionFactory.
        /// </summary>
        private readonly IConnectionFactory _connectionFactory;

        /// <summary>
        /// Defines the _connection.
        /// </summary>
        private IConnection _connection;

        /// <summary>
        /// Defines the _disposed.
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="RabbitMQConnection"/> class.
        /// </summary>
        /// <param name="connectionFactory">The connectionFactory<see cref="IConnectionFactory"/>.</param>
        public RabbitMQConnection(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

            if (!IsConnected)
            {
                TryConnect();
            }
        }

        /// <summary>
        /// The TryConnect.
        /// </summary>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool TryConnect()
        {
            try
            {
                _connection = _connectionFactory.CreateConnection();
            }
            catch (BrokerUnreachableException ex)
            {
                Thread.Sleep(2000);
                _connection = _connectionFactory.CreateConnection();
            }

            return IsConnected;
        }

        /// <summary>
        /// The CreateModel.
        /// </summary>
        /// <returns>The <see cref="IModel"/>.</returns>
        public IModel CreateModel()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("no rabbit connection");
            }

            return _connection.CreateModel();
        }

        /// <summary>
        /// The Dispose.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return;

            try
            {
                _connection.Dispose();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Gets a value indicating whether IsConnected.
        /// </summary>
        public bool IsConnected
        {
            get { return _connection != null && _connection.IsOpen && !_disposed; }
        }
    }
}
