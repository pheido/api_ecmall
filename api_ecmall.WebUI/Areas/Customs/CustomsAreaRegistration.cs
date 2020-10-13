using System.Web.Mvc;

namespace api_ecmall.WebUI.Areas.Customs
{
    /// <summary>
    /// 
    /// </summary>
    public class CustomsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Customs";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Customs_default",
                "Customs/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}