using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Entities.Pay;
using Com.Alipay;
using api_ecmall.Domain.Abstract;
using RestSharp;
using api_ecmall.Domain.Utils;
using System.Xml.Serialization;
using System.IO;

namespace api_ecmall.Domain.Concrete
{
    public class AlipayRepository:IAlipayRepository
    {
        /// <summary>
        /// 提交给支付宝支付报关
        /// </summary>
        /// <param name="order">支付报关实体</param>
        /// <param name="alipaySec">秘钥</param>
        /// <returns>支付报关结果</returns>
        public alipay alipay_update(AliPayOrder order,string alipaySec)
        {
            alipay model = new alipay();
            order.service = "alipay.acquire.customs";
            order._input_charset = "utf-8";
            order.sign_type = "MD5";
            order.partner = "2088531118503209";
            order.merchant_customs_code = "121096080H";
            order.merchant_customs_name = "天津智信通电子商务有限公司";
            //order.partner = "2088102177882682";联调测试
            StringBuilder strBuild = SignsHelper.signBuild(order);
            try
            {
                alipaySec = "ujsidc9esjszyov0fc0trsveq733ttvd";
                string signStr = SignsHelper.sign(strBuild, alipaySec);
                strBuild.Append("&sign=" + signStr);
                strBuild.Append("&sign_type=MD5");
                string urlStr = "https://mapi.alipay.com/gateway.do?" + strBuild.ToString();
                //string urlStr = "https://openapi.alipaydev.com/gateway.do?" + strBuild.ToString();
                var client = new RestClient(urlStr);
                var request = new RestRequest(Method.GET);
                request.AddHeader("cache-control", "no-cache");
                IRestResponse re = client.Execute(request);

                XmlSerializer serializer = new XmlSerializer(typeof(alipay));
                using (StringReader reader = new StringReader(re.Content))
                {
                    model = (alipay)serializer.Deserialize(reader);
                }

            }
            catch(Exception ex)
            {

            }
            return model;
        }


        /// <summary>
        /// 查询给支付宝支付报关
        /// </summary>
        /// <param name="order">支付报关实体</param>
        /// <param name="alipaySec">秘钥</param>
        /// <returns>支付报关结果</returns>
        public alipay alipay_get(AliPayOrder order, string alipaySec)
        {
            alipay model = new alipay();
            order.service = "alipay.overseas.acquire.customs.query";
            order._input_charset = "UTF-8";
            order.sign_type = "MD5";
            order.partner = "2088531118503209";
            order.merchant_customs_code = "121096080H";
            order.merchant_customs_name = "天津智信通电子商务有限公司";
            //order.partner = "2088102177882682";联调测试
            StringBuilder strBuild = SignsHelper.signBuild_get(order);
            try
            {
                alipaySec = "ujsidc9esjszyov0fc0trsveq733ttvd";
                string signStr = SignsHelper.sign(strBuild, alipaySec);
                strBuild.Append("&sign=" + signStr);
                strBuild.Append("&sign_type=MD5");
                string urlStr = "https://mapi.alipay.com/gateway.do?" + strBuild.ToString();
                //string urlStr = "https://openapi.alipaydev.com/gateway.do?" + strBuild.ToString();
                var client = new RestClient(urlStr);
                var request = new RestRequest(Method.GET);
                request.AddHeader("cache-control", "no-cache");
                IRestResponse re = client.Execute(request);//_input_charset=utf-8&out_request_no=string&partner=2088531118503209&service=alipay.acquire.customs&sign=3c9fa6e2ff865717adb5b227e2d800ea&sign_type=MD5

                XmlSerializer serializer = new XmlSerializer(typeof(alipay));
                using (StringReader reader = new StringReader(re.Content))
                {
                    model = (alipay)serializer.Deserialize(reader);
                }

            }
            catch (Exception ex)
            {

            }
            return model;
        }
    }
}
