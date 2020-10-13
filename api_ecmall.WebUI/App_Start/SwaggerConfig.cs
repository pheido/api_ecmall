using System.Web.Http;
using WebActivatorEx;
using api_ecmall.WebUI;
using Swashbuckle.Application;
using api_ecmall.WebUI.App_Start;
using System.Reflection;
using System.Linq;
using api_ecmall.WebUI.Infrastructure;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace api_ecmall.WebUI
{
    /// <summary>
    /// 
    /// </summary>
    public class SwaggerConfig
    {
        /// <summary>
        /// 
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                {
                    c.SingleApiVersion("v1", "API v1.0");
                    c.IncludeXmlComments(GetXmlCommentsPath());
                    c.DocumentFilter<HiddenApiFilter>();
                    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                    c.CustomProvider((defaultProvider) => new SwaggerControllerDescProvider(defaultProvider, GetXmlCommentsPath()));
                })
                .EnableSwaggerUi(c =>
                {
                    //c.InjectJavaScript(Assembly.GetExecutingAssembly(), "api_ecmall.WebUI.Scripts.swaggerUI.js");
                    c.InjectJavaScript(thisAssembly, "api_ecmall.WebUI.Scripts.swaggerUI.js");
                    //c.InjectStylesheet(thisAssembly, "api_ecmall.WebUI.SwaggerUI.index.html");
                });
        }
        private static string GetXmlCommentsPath()
        {
            return string.Format("{0}/bin/api_ecmall.WebUI.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
