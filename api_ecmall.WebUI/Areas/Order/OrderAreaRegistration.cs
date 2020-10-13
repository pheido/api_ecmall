using System.Web.Mvc;

namespace api_ecmall.WebUI.Areas.Orders
{
    /// <summary>
    /// 
    /// </summary>
    public class OrderAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Order";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Order_default",
                "Order/{controller}/{id}",
                new { id = UrlParameter.Optional }
            );
        }
    }
}