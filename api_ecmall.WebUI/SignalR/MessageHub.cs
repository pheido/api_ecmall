using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using api_ecmall.Domain.Entities;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Net;
using System.Text;
using System.Threading;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Concrete;

namespace api_ecmall.WebUI.SignalR
{
    /// <summary>
    /// 
    /// </summary>
    [HubName("messagehub")]
    [Authorize]
    public class MessageHub:Hub
    {
        private ILog4netHelper _ILog4netHelper = new Log4netHelper();
        static int i = 0;
        /// <summary>
        /// 
        /// </summary>
        /// 
        public MessageHub(/*ILog4netHelper ILog4netHelper*/)
        {
            if (i == 0)
            {
                //_ILog4netHelper = ILog4netHelper;
                i++;
                //MessageHelper.envenMessageHelp += new MessageHelp(Send);
                //OrderToOMS();
                //PayToOMS();
                //Order311FromOMS_TianJin();
                //Order311FromOMS_GuangZhou();
                Task.Factory.StartNew(()=> {
                    customrealpayController();
                    //Order311FromOMS_TianJin();
                    Order311FromOMS_GuangZhou();
                });
            }
        }
        static Dictionary<string, string> dic = new Dictionary<string, string>();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        public void Send(payExInfo info)
        {
            try
            {
                string id = Context.ConnectionId;
                string name = Context.User.Identity.Name;
                if (!string.IsNullOrEmpty(name))
                {
                    if (!dic.ContainsKey(name))
                    {
                        dic.Add(name, id);
                    }
                    else
                    {
                        dic[name] = id;
                    }
                }
                //Clients.Client(dic["test@qq.com"]).Send(info);
                Clients.User("test@qq.com").Send(info);
            }
            catch(Exception ex)
            {

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Task OnConnected()
        {
            string id = Context.ConnectionId;
            string name = Context.User.Identity.Name;
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    if (!dic.ContainsKey(name))
                    {
                        dic.Add(name, id);
                    }
                    else
                    {
                        dic[name] = id;
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return base.OnConnected();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stopCalled"></param>
        /// <returns></returns>
        public override Task OnDisconnected(bool stopCalled)
        {
            string id = Context.ConnectionId;
            string name = Context.User.Identity.Name;
            dic.Remove(name);
            return base.OnDisconnected(stopCalled);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Task OnReconnected()
        {
            string id = Context.ConnectionId;
            string name = Context.User.Identity.Name;
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    if (!dic.ContainsKey(name))
                    {
                        dic.Add(name, id);
                    }
                    else
                    {
                        dic[name] = id;
                    }
                }
            }
            catch(Exception ex)
            {

            }
            return base.OnReconnected();
        }
        /// <summary>
        /// 
        /// </summary>
        public void customrealpayController()
        {
            try
            {
                ConcurrentQueue<BasicDeliverEventArgs> queue1 = new ConcurrentQueue<BasicDeliverEventArgs>();
                ConnectionFactory factory = new ConnectionFactory();
                factory.UserName = "guest";
                factory.Password = "guest";
                factory.HostName = "127.0.0.1";
                factory.Port = 5672;
                factory.AutomaticRecoveryEnabled = true;
                factory.TopologyRecoveryEnabled = true;


                RabbitMQ.Client.IConnection conn = factory.CreateConnection();
                conn.ConnectionShutdown += (o, e) => {

                };
                IModel channel = conn.CreateModel();
                channel.ExchangeDeclare("customrealpayController", "direct");
                channel.QueueDeclare("customrealpayController", false, false, false, null);
                channel.QueueBind("customrealpayController", "customrealpayController", "customrealpayController", null);

                EventingBasicConsumer c = new EventingBasicConsumer(channel);
                c.Received += (ch, ea) =>
                {
                    queue1.Enqueue(ea);
                };
                string consumerTag = channel.BasicConsume("customrealpayController", false, c);
                Task.Factory.StartNew(() => {
                    BasicDeliverEventArgs bdea = null;
                    while (true)
                    {
                        if (queue1.TryDequeue(out bdea))
                        {
                            try
                            {

                                //Clients.User("test@qq.com").Send(JsonConvert.DeserializeObject<payExInfo>(Encoding.UTF8.GetString(bdea.Body)));
                                //channel.BasicAck(bdea.DeliveryTag, false);



                                if (dic.Keys.Contains("test@qq.com"))
                                {
                                    Clients.User("test@qq.com").Send(JsonConvert.DeserializeObject<payExInfo>(Encoding.UTF8.GetString(bdea.Body)));
                                    channel.BasicAck(bdea.DeliveryTag, false);
                                }
                                else
                                {
                                    channel.BasicAck(bdea.DeliveryTag, true);
                                }
                            }
                            catch (Exception ex)
                            {
                                channel.BasicNack(bdea.DeliveryTag, false, true);
                            }
                        }
                        Thread.Sleep(100);
                    }
                });
            }
            catch (Exception ex)
            {
                customrealpayController();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        public void Order311FromOMS_TianJin()
        {
            try
            {
                ConcurrentQueue<BasicDeliverEventArgs> queue1 = new ConcurrentQueue<BasicDeliverEventArgs>();
                ConnectionFactory factory = new ConnectionFactory();
                factory.UserName = "guest";
                factory.Password = "guest";
                factory.HostName = "127.0.0.1";
                factory.Port = 5672;
                factory.AutomaticRecoveryEnabled = true;
                factory.TopologyRecoveryEnabled = true;


                RabbitMQ.Client.IConnection conn = factory.CreateConnection();
                conn.ConnectionShutdown += (o, e) => {

                };
                IModel channel = conn.CreateModel();
                channel.ExchangeDeclare("custom311Controller", "direct");
                channel.QueueDeclare("custom311Controller", false, false, false, null);
                channel.QueueBind("custom311Controller", "custom311Controller", "custom311Controller", null);

                EventingBasicConsumer c = new EventingBasicConsumer(channel);
                c.Received += (ch, ea) =>
                {
                    queue1.Enqueue(ea);
                };
                string consumerTag = channel.BasicConsume("custom311Controller", false, c);
                Task.Factory.StartNew(() => {
                    BasicDeliverEventArgs bdea = null;
                    while (true)
                    {
                        if (queue1.TryDequeue(out bdea))
                        {
                            try
                            {
                                //Clients.User("test@qq.com").Send_Order311(Encoding.UTF8.GetString(bdea.Body));
                                //channel.BasicAck(bdea.DeliveryTag, false);


                                if (dic.Keys.Contains("test@qq.com"))
                                {
                                    Clients.User("test@qq.com").Send_Order311(Encoding.UTF8.GetString(bdea.Body));
                                    channel.BasicAck(bdea.DeliveryTag, false);
                                }
                                else
                                {
                                    channel.BasicNack(bdea.DeliveryTag, false, true);
                                    //channel.BasicAck(bdea.DeliveryTag, true);
                                }
                            }
                            catch (Exception ex)
                            {
                                channel.BasicNack(bdea.DeliveryTag, false, true);
                            }
                        }
                        Thread.Sleep(100);
                    }
                });
            }
            catch (Exception ex)
            {
                Order311FromOMS_TianJin();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Order311FromOMS_GuangZhou()
        {
            try
            {
                ConcurrentQueue<BasicDeliverEventArgs> queue1 = new ConcurrentQueue<BasicDeliverEventArgs>();
                ConnectionFactory factory = new ConnectionFactory();
                factory.UserName = "guest";
                factory.Password = "guest";
                factory.HostName = "127.0.0.1";
                factory.Port = 5672;
                factory.AutomaticRecoveryEnabled = true;
                factory.TopologyRecoveryEnabled = true;


                RabbitMQ.Client.IConnection conn = factory.CreateConnection();
                conn.ConnectionShutdown += (o, e) => {

                };
                IModel channel = conn.CreateModel();
                channel.ExchangeDeclare("ENT311Message_GuangZhou", "direct");
                channel.QueueDeclare("ENT311Message_GuangZhou", false, false, false, null);
                channel.QueueBind("ENT311Message_GuangZhou", "ENT311Message_GuangZhou", "ENT311Message_GuangZhou", null);

                EventingBasicConsumer c = new EventingBasicConsumer(channel);
                c.Received += (ch, ea) =>
                {
                    queue1.Enqueue(ea);
                };
                string consumerTag = channel.BasicConsume("ENT311Message_GuangZhou", false, c);
                Task.Factory.StartNew(() => {
                    BasicDeliverEventArgs bdea = null;
                    while (true)
                    {
                        if (queue1.TryDequeue(out bdea))
                        {
                            try
                            {
                                _ILog4netHelper.WriteLog_Info<MessageHub>(Encoding.UTF8.GetString(bdea.Body), dic.Count.ToString(), null, null);
                                if (dic.Keys.Contains("test@qq.com"))
                                {
                                     Clients.User("test@qq.com").Send_Order311_GuangZhou(Encoding.UTF8.GetString(bdea.Body));
                                    //_ILog4netHelper.WriteLog_Info<MessageHub>(re, dic.Count.ToString(), null, null);
                                    channel.BasicAck(bdea.DeliveryTag, false);
                                }
                                else
                                {
                                    channel.BasicNack(bdea.DeliveryTag, false, true);
                                    //channel.BasicAck(bdea.DeliveryTag, true);
                                }
                            }
                            catch (Exception ex)
                            {
                                _ILog4netHelper.WriteLog_Info<MessageHub>(Encoding.UTF8.GetString(bdea.Body), dic.Count.ToString(), null, ex);
                                try
                                {
                                    channel.BasicNack(bdea.DeliveryTag, false, true);
                                }
                                catch(Exception exe)
                                {
                                    //Order311FromOMS_GuangZhou();
                                }
                            }
                        }
                        Thread.Sleep(100);
                    }
                });
            }
            catch (Exception ex)
            {
                Order311FromOMS_GuangZhou();
            }
        }
    }
}