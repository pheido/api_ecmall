using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Alipay;

namespace api_ecmall.Domain.Utils
{
    public class SignsHelper
    {
        public static StringBuilder signBuild(AliPayOrder alipayOrder)
        {
            if (alipayOrder == null)
            {
                return null;
            }
            StringBuilder strBuild = new StringBuilder();
            strBuild.Append("_input_charset=" + alipayOrder._input_charset + "&");
            strBuild.Append("amount=" + alipayOrder.amount + "&");
            strBuild.Append("buyer_id_no=" + alipayOrder.buyer_id_no + "&");
            strBuild.Append("buyer_name=" + alipayOrder.buyer_name + "&");
            strBuild.Append("customs_place=" + alipayOrder.customs_place + "&");
            strBuild.Append("is_split=" + alipayOrder.is_split + "&");
            strBuild.Append("merchant_customs_code=" + alipayOrder.merchant_customs_code + "&");
            strBuild.Append("merchant_customs_name=" + alipayOrder.merchant_customs_name + "&");
            strBuild.Append("out_request_no=" + alipayOrder.out_request_no + "&");
            strBuild.Append("partner=" + alipayOrder.partner + "&");
            strBuild.Append("service=" + alipayOrder.service + "&");
            strBuild.Append("trade_no=" + alipayOrder.trade_no);
            //strBuild.Append("pujughw1hy7aetkwo3y98tqk8jzy2a0d");
            return strBuild;
        }
        public static StringBuilder signBuild_get(AliPayOrder alipayOrder)
        {
            if (alipayOrder == null)
            {
                return null;
            }
            StringBuilder strBuild = new StringBuilder();
            strBuild.Append("_input_charset=" + alipayOrder._input_charset + "&");
            //strBuild.Append("amount=" + alipayOrder.amount + "&");
            //strBuild.Append("buyer_id_no=" + alipayOrder.buyer_id_no + "&");
            //strBuild.Append("buyer_name=" + alipayOrder.buyer_name + "&");
            //strBuild.Append("customs_place=" + alipayOrder.customs_place + "&");
            //strBuild.Append("is_split=" + alipayOrder.is_split + "&");
            //strBuild.Append("merchant_customs_code=" + alipayOrder.merchant_customs_code + "&");
            //strBuild.Append("merchant_customs_name=" + alipayOrder.merchant_customs_name + "&");
            strBuild.Append("out_request_nos=" + alipayOrder.out_request_no + "&");
            strBuild.Append("partner=" + alipayOrder.partner + "&");
            strBuild.Append("service=" + alipayOrder.service);
            //strBuild.Append("trade_no=" + alipayOrder.trade_no);
            //strBuild.Append("pujughw1hy7aetkwo3y98tqk8jzy2a0d");
            return strBuild;
        }

        public static string sign(StringBuilder strBuild, string key)
        {
            if (strBuild == null)
            {
                return null;
            }
            string instr = strBuild.ToString().Trim();
            //instr.Append("pujughw1hy7aetkwo3y98tqk8jzy2a0d");
            string inputStr = instr + key.Trim();
            string outputStr = MD5Helper.MD5Encrypt(inputStr);
            return outputStr;
        }
    }
}
