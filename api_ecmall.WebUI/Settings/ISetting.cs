using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_ecmall.WebUI.Settings
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISetting
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        OMS_Setting oms { get; }
        /// <summary>
        /// 
        /// </summary>
        Ecmall_Setting ecmall { get; }
        /// <summary>
        /// 
        /// </summary>
        Customs_Server_Setting custom { get; }
        /// <summary>
        /// 
        /// </summary>
        Wms_Server_Setting wms { get; }
        /// <summary>
        /// 
        /// </summary>
        Erp_Setting erp { get; }
    }
}
