using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Entities.Pay;
using api_ecmall.Domain.Abstract;
using System.Reflection;
using System.Security.Cryptography;

namespace api_ecmall.Domain.Concrete
{
    public class WxpayRepository:IWxpayRepository
    {
        public wxpay_re WxpayCustom(wxpay value)
        {
            string stringA = wxsign(value);
            value.sign = stringA;
            return null;
        }
        private string wxsign(wxpay value)
        {
            StringBuilder strRe = new StringBuilder();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            Type t = value.GetType();
            foreach(PropertyInfo pi in t.GetProperties())
            {
                var strValue = pi.GetValue(value, null);
                if (strValue != null)
                {
                    dic.Add(pi.Name, strValue.ToString());
                }
            }
            int index = 0;
            foreach (var item in dic)
            {
                if (index == 0)
                {
                    strRe.Append(item.Key + "=" + item.Value);
                    index++;
                }
                else
                {
                    strRe.Append("&"+item.Key + "=" + item.Value);
                }
            }
            string signs = "";
            MD5 md5 = MD5.Create();
            byte[] by = md5.ComputeHash(Encoding.UTF8.GetBytes(strRe.ToString()));
            for (int i = 0; i < by.Length; i++)
            {
                signs += by[i].ToString("X");
            }

            return signs;
        }
    }
}
