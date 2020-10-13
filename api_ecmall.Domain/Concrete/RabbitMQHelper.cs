using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Abstract;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System.Collections.Concurrent;
using System.Threading;
using System.Runtime.CompilerServices;

namespace api_ecmall.Domain.Concrete
{
    public class RabbitMQHelper:IRabbitMQHelper
    {
        static ConnectionFactory factory = new ConnectionFactory();
        static IConnection _connection;// = factory.CreateConnection();
        private readonly static object lockObj = new object();


        //private readonly static ConcurrentQueue<IConnection> FreeConnectionQueue;//空闲连接对象队列
        //private readonly static Semaphore MQConnectionPoolSemaphore;
        //static RabbitMQHelper()
        //{
        //    FreeConnectionQueue = new ConcurrentQueue<IConnection>();
        //    MQConnectionPoolSemaphore = new Semaphore(10,10);
        //    for (int i = 0; i < 10; i++)
        //    {
        //        factory.UserName = "test";
        //        factory.Password = "test";
        //        factory.HostName = "127.0.0.1";
        //        IConnection iconn = factory.CreateConnection();
        //        FreeConnectionQueue.Enqueue(iconn);
        //    }
        //}
        public static IConnection Connection()
        {
            lock (lockObj)
            {
                try
                {
                    if (_connection == null || !_connection.IsOpen)
                    {
                        factory.UserName = "guest";
                        factory.Password = "guest";
                        factory.HostName =  "127.0.0.1";
                        factory.Port =  5672;
                        _connection = factory.CreateConnection();
                    }
                }
                catch
                {
                    factory = new ConnectionFactory();
                    factory.UserName = "guest";
                    factory.Password = "guest";
                    factory.HostName = "127.0.0.1";
                    factory.Port = 5672;
                    _connection = factory.CreateConnection();
                }
            }
            return _connection;
        }
        public bool Publish<T>(string Message) where T:class
        {
            //FreeConnectionQueue.TryDequeue(out _connection);
            if (_connection == null || !_connection.IsOpen)
            {
                _connection = Connection();
            }
            Task.Factory.StartNew(()=> {
                Test<T>(Message);
            });
            return true;
        }
        public bool Publish_Delay<T>(string Message, string name_delay) where T : class
        {
            //FreeConnectionQueue.TryDequeue(out _connection);
            if (_connection == null || !_connection.IsOpen)
            {
                _connection = Connection();
            }
            Task.Factory.StartNew(() => {
                Test_Delay<T>(Message, name_delay);
            });
            return true;
        }
        private void Test<T>(string Message) where T : class
        {
            string name = typeof(T).Name;
            using (var channel = _connection.CreateModel())
            {
                try
                {
                    channel.ExchangeDeclare(name, "direct");
                    channel.QueueDeclare(name, false, false, false, null);
                    channel.QueueBind(name, name, name, null);
                    byte[] messageBodyBytes = Encoding.UTF8.GetBytes(Message);
                    channel.BasicPublish(name, name, true, null, messageBodyBytes);
                }
                catch (Exception ex)
                {
                    //return false;
                }
                //FreeConnectionQueue.Enqueue(_connection);
            }
        }
        private void Test_Delay<T>(string Message,string name_delay) where T : class
        {
            string name = typeof(T).Name;
            using (var channel = _connection.CreateModel())
            {
                try
                {
                    Dictionary<string, object> dic = new Dictionary<string, object>();
                    //dic.Add("x-expires", 36000);
                    dic.Add("x-message-ttl", 320000);
                    dic.Add("x-dead-letter-exchange", name_delay);
                    dic.Add("x-dead-letter-routing-key", name_delay);
                    channel.ExchangeDeclare(name, "direct");
                    channel.QueueDeclare(name, false, false, false, dic);
                    channel.QueueBind(name, name, name, null);
                    byte[] messageBodyBytes = Encoding.UTF8.GetBytes(Message);
                    channel.BasicPublish(name, name, true, null, messageBodyBytes);
                }
                catch (Exception ex)
                {
                    //return false;
                }
                //FreeConnectionQueue.Enqueue(_connection);
            }
        }
    }
}
