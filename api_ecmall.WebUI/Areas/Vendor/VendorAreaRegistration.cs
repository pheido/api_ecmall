using System.Web.Mvc;

namespace api_ecmall.WebUI.Areas.Vendor
{
    /// <summary>
    /// 
    /// </summary>
    public class VendorAreaRegistration : AreaRegistration 
    {
        /// <summary>
        /// 
        /// </summary>
        public override string AreaName 
        {
            get 
            {
                return "Vendor";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Vendor_default",
                "Vendor/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}