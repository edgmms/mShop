using mShop.EventBus.Events;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mShop.EventBus.Producer
{
    public class RabbitMQProducer
    {
        private readonly IRabbitMQConnection _rabbitMQConnection;

        public RabbitMQProducer(IRabbitMQConnection rabbitMQConnection)
        {
            _rabbitMQConnection = rabbitMQConnection;
        }

        public void Publish<TPublishModel>(string queueName, TPublishModel publishModel) where TPublishModel : BaseEventModel
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
