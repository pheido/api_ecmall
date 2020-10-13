using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Swashbuckle.Swagger;
using System.Web.Http.Description;

namespace api_ecmall.WebUI.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public partial class HiddenApiAttribute : Attribute { }
    /// <summary>
    /// 
    /// </summary>
    public class HiddenApiFilter:IDocumentFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="swaggerDoc"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiExplorer"></param>
        public void Apply(SwaggerDocument swaggerDoc, SchemaRegistry schemaRegistry, IApiExplorer apiExplorer)
        {
            foreach (ApiDescription apiDescription in apiExplorer.ApiDescriptions)
            {
                if (Enumerable.OfType<HiddenApiAttribute>(apiDescription.GetControllerAndActionAttributes<HiddenApiAttribute>()).Any())
                {
                    string key = "/" + apiDescription.RelativePath;
                    if (key.Contains("?"))
                    {
                        int idx = key.IndexOf("?", StringComparison.Ordinal);
                        key = key.Substring(0, idx);
                    }
                    swaggerDoc.paths.Remove(key);
                }
                if(apiDescription.RelativePath.Contains("Swagger"))
                {
                    string key = "/" + apiDescription.RelativePath;
                    if (key.Contains("?"))
                    {
                        int idx = key.IndexOf("?", StringComparison.Ordinal);
                        key = key.Substring(0, idx);
                    }
                    swaggerDoc.paths.Remove(key);
                }
            }
        }
    }
}