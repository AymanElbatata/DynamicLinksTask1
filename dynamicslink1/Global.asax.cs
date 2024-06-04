using dynamicslink1.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace dynamicslink1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            MyBundleCls.MyBundleJSCS(BundleTable.Bundles);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
