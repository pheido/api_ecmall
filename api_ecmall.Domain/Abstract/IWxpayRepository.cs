using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Entities.Pay;

namespace api_ecmall.Domain.Abstract
{
    public interface IWxpayRepository
    {
        wxpay_re WxpayCustom(wxpay value);
    }
}
