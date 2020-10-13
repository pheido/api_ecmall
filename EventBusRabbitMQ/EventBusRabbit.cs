using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using Newtonsoft.Json;
using Polly;
using Polly.Retry;
using System.Net.Sockets;
using EventBusRabbitMQ;

namespace EventBusRabbitMQ
{
    public class EventBusRabbit :IEventBusRabbitMQ
    {
        const string BROKER_NAME = "ecmall_event_bus";

        private readonly IRabbitMQPersistentConnection _persistentConnection;
        private readonly int _retryCount;

        private IModel _consumerChannel;
        private string _queueName;

        public EventBusRabbit(/*IRabbitMQPersistentConnection persistentConnection*/
             /*string queueName = null, int retryCount = 5*/)
        {
            var _connection = new ConnectionFactory()
            {
                UserName = "test",
                Password = "test",
                HostName = "127.0.0.1"
            };
            _persistentConnection = _persistentConnection?? new DefaultRabbitMQPersistentConnection(_connection);// persistentConnection;
            //_queueName = queueName;
            //_retryCount = retryCount;
        }

        private void SubsManager_OnEventRemoved(object sender, string eventName)
        {
            if (!_persistentConnection.IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            using (var channel = _persistentConnection.CreateModel())
            {
                channel.QueueUnbind(queue: _queueName,
                    exchange: BROKER_NAME,
                    routingKey: eventName);
            }
        }

        public void Publish(object @event)
        {
            try
            {
                if (!_persistentConnection.IsConnected)
                {
                    _persistentConnection.TryConnect();
                }

                var policy = RetryPolicy.Handle<BrokerUnreachableException>()
                    .Or<SocketException>()
                    .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
                    {
                    //_logger.LogWarning(ex, "Could not publish event: {EventId} after {Timeout}s ({ExceptionMessage})", @event.Id, $"{time.TotalSeconds:n1}", ex.Message);
                });

                using (var channel = _persistentConnection.CreateModel())
                {
                    var eventName = @event.GetType()
                        .Name;

                    channel.ExchangeDeclare(exchange: BROKER_NAME,
                                        type: "direct");

                    channel.QueueDeclare(BROKER_NAME, false, false, false, null);
                    channel.QueueBind(BROKER_NAME, BROKER_NAME, BROKER_NAME, null);

                    //var message = JsonConvert.SerializeObject(@event);
                    var body = Encoding.UTF8.GetBytes("haha");

                    policy.Execute(() =>
                    {
                        var properties = channel.CreateBasicProperties();
                        properties.DeliveryMode = 2; // persistent

                    channel.BasicPublish(exchange: BROKER_NAME,
                                         routingKey: BROKER_NAME,
                                         mandatory: true,
                                         basicProperties: properties,
                                         body: body);
                    });
                }
            }
            catch(Exception ex)
            {

            }
        }

       

        public void Dispose()
        {
            if (_consumerChannel != null)
            {
                _consumerChannel.Dispose();
            }

            //_subsManager.Clear();
        }

        //private IModel CreateConsumerChannel()
        //{
        //    if (!_persistentConnection.IsConnected)
        //    {
        //        _persistentConnection.TryConnect();
        //    }

        //    var channel = _persistentConnection.CreateModel();

        //    channel.ExchangeDeclare(exchange: BROKER_NAME,
        //                         type: "direct");

        //    channel.QueueDeclare(queue: _queueName,
        //                         durable: true,
        //                         exclusive: false,
        //                         autoDelete: false,
        //                         arguments: null);


        //    var consumer = new EventingBasicConsumer(channel);
        //    consumer.Received += async (model, ea) =>
        //    {
        //        var eventName = ea.RoutingKey;
        //        var message = Encoding.UTF8.GetString(ea.Body);

        //        //await ProcessEvent(eventName, message);

        //        channel.BasicAck(ea.DeliveryTag, multiple: false);
        //    };

        //    channel.BasicConsume(queue: _queueName,
        //                         autoAck: false,
        //                         consumer: consumer);

        //    channel.CallbackException += (sender, ea) =>
        //    {
        //        _consumerChannel.Dispose();
        //        _consumerChannel = CreateConsumerChannel();
        //    };

        //    return channel;
        //}
    }
}
