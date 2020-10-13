using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Entities.Pay;
using Com.Alipay;

namespace api_ecmall.Domain.Abstract
{
    public interface IAlipayRepository
    {
        /// <summary>
        /// 提交给支付宝支付报关
        /// </summary>
        /// <param name="order">支付报关实体</param>
        /// <returns>支付报关结果</returns>
        alipay alipay_update(AliPayOrder order, string alipaySec);
        alipay alipay_get(AliPayOrder order, string alipaySec);
    }
}
