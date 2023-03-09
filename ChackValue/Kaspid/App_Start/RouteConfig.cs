using System.Security.Policy;
using Kaspid.App_Start;
using System.Web.Mvc;
using System.Web.Routing;

namespace Kaspid
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Default

            //route default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}/{title}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, title = UrlParameter.Optional.ToString() },
                constraints: new { controller = new Kaspid.App_Start.ValidControllerAction() },
                namespaces: new[] { "Kaspid.Controllers" }

            );

            #endregion
        }
    }
}