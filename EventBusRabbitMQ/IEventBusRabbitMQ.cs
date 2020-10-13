using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ
{
    public interface IEventBusRabbitMQ:IDisposable
    {
        void Publish(object @event);
    }
}
