using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Layout;
using log4net.Layout.Pattern;
using log4net.Core;

namespace api_ecmall.Domain.Concrete.Log4net
{
    public class ActionLayoutPattern:PatternLayout
    {
        public ActionLayoutPattern()
        {
            this.AddConverter("actionInfo",typeof(ActionConverter));
        }
    }
}
