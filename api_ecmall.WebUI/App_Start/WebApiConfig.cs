using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using api_ecmall.WebUI.Infrastructure;
using System.Web.Http.Cors;

namespace api_ecmall.WebUI
{
    /// <summary>
    /// 
    /// </summary>
    public static class WebApiConfig
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="config"></param>
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // 将 Web API 配置为仅使用不记名令牌身份验证。
            config.DependencyResolver = NinjectDependencyResolver.Current;
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
            // Web API 路由
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "AreastApi",
                routeTemplate: "api/{areas}/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //config.EnableCors();
            //config.EnableCors(new EnableCorsAttribute("*", "*","*"));
        }
    }
}
