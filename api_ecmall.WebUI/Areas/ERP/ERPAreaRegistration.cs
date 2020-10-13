﻿using System.Web.Mvc;

namespace api_ecmall.WebUI.Areas.ERP
{
    public class ERPAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ERP";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ERP_default",
                "ERP/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}