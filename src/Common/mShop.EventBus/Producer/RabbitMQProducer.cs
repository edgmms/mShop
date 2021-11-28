using mShop.EventBus.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace mShop.EventBus.Producer
{
    /// <summary>
    /// Defines the <see cref="RabbitMQProducer" />.
    /// </summary>
    public partial class RabbitMQProducer
    {
        /// <summary>
        /// Defines the _rabbitMQConnection.
        /// </summary>
        private readonly IRabbitMQConnection _rabbitMQConnection;

        /// <summary>
        /// Initializes a new instance of the <see cref="RabbitMQProducer"/> class.
        /// </summary>
        /// <param name="rabbitMQConnection">The rabbitMQConnection<see cref="IRabbitMQConnection"/>.</param>
        public RabbitMQProducer(IRabbitMQConnection rabbitMQConnection)
        {
            _rabbitMQConnection = rabbitMQConnection;
        }

        /// <summary>
        /// The Publish.
        /// </summary>
        /// <typeparam name="TPublishModel">.</typeparam>
        /// <param name="queueName">The queueName<see cref="string"/>.</param>
        /// <param name="publishModel">The publishModel<see cref="TPublishModel"/>.</param>
        public void Publish<TPublishModel>(string queueName, TPublishModel publishModel) where TPublishModel : BaseEvent
        {
            using (var channel = _rabbitMQConnection.CreateModel())
            {
                channel.QueueDeclare(queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                var message = JsonConvert.SerializeObject(publishModel);
                var body = Encoding.UTF8.GetBytes(message);

                IBasicProperties properties = channel.CreateBasicProperties();
                properties.Persistent = true;
                properties.DeliveryMode = 2;

                channel.ConfirmSelect();
                channel.BasicPublish(exchange: "", routingKey: queueName, mandatory: true, basicProperties: properties, body: body);
                channel.WaitForConfirmsOrDie();

                channel.BasicAcks += (sender, eventArgs) =>
                {
                    Console.WriteLine("Sent RabbitMQ");
                    //implement ack handle
                };
                channel.ConfirmSelect();

            }
        }
    }
}
