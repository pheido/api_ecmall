using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(api_ecmall.WebUI.Startup))]

namespace api_ecmall.WebUI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //app.MapSignalR();
        }
    }
}
