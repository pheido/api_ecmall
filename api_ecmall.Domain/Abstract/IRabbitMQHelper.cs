using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.Domain.Abstract
{
    public interface IRabbitMQHelper
    {
       bool Publish<T>(string Message) where T:class;
       bool Publish_Delay<T>(string Message, string name_delay) where T : class;
    }
}
