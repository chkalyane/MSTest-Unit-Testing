using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using YesMed.Configurations;
using System.Net.Http;

namespace YesMed
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public object WEBAPICONFIG { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            AutofacConfiguration.Load();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = true;
        }
    }
}
