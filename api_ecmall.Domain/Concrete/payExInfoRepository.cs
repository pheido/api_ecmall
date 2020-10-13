using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_ecmall.Domain.Abstract;
using api_ecmall.Domain.Entities;
using api_ecmall.Domain.Concrete;

namespace api_ecmall.Domain.Concrete
{
    public class payExInfoRepository: IpayExInfoRepository
    {
        private ILog4netHelper _ILog4netHelper;
        public payExInfoRepository(ILog4netHelper ILog4netHelper)
        {
            _ILog4netHelper = ILog4netHelper;
        }
        EFDbContext context = new EFDbContext();
        public IEnumerable<payExInfo_DTO> payExInfoes { get { return context.payExInfoes.Include("payExchangeInfoHead").Include("payExchangeInfoLists"); } }
        public void payExInfo_Save(payExInfo_DTO info)
        {
            try
            {
                payExInfo_DTO dto = new payExInfo_DTO();
                if (info.payExchangeInfoLists.Count > 0&&info.type==1)
                {
                    dto = payExInfoes.Where(t => t.payguid == (t.payExchangeInfoLists.Where(x => x.orderNo == info.payExchangeInfoLists[0].orderNo).Select(c => c.payguid).ToList().FirstOrDefault())&&t.type==1).ToList().FirstOrDefault();
                }
                if (dto == null||dto.payguid==Guid.Empty)
                {
                    context.payExInfoes.Add(info);
                }
                else
                {
                    //context.payExInfoes.Add(info);
                    dto.payExchangeInfoHead[0].initalResponse = info.payExchangeInfoHead[0].initalResponse;
                    dto.payExchangeInfoHead[0].payTransactionId = info.payExchangeInfoHead[0].payTransactionId;
                    dto.payExchangeInfoHead[0].tradingTime = info.payExchangeInfoHead[0].tradingTime;
                    dto.payment_type = info.payment_type;
                    dto.is_success = info.is_success;
                    //dto.payExchangeInfoHead[0].payCode = info.payExchangeInfoHead[0].payCode;
                }
                context.SaveChanges();
            }
            catch(Exception ex)
            {
                _ILog4netHelper.WriteLog_Error<payExInfoRepository>("保存支付信息错误",null,null,ex);
            }
        }
    }
}
