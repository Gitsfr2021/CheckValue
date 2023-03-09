using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Kaspid
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
            MvcHandler.DisableMvcResponseHeader = true;
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            BundleTable.EnableOptimizations = true;
        }

        protected void Application_PreSendRequestHeaders(object source, EventArgs e)
        {
            if (HttpContext.Current != null)
            {
                HttpContext.Current.Response.Headers.Remove("Server");
            }
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            string route1 = "/products/detail/خودروهای-بنزینی/";


            if (HttpContext.Current.Request.Url.LocalPath.ToLower() == route1.ToLower())
            {
                Response.Redirect("https://www.arvandshahab.com/products/engine-oil/");
            }
        }
    }
}
