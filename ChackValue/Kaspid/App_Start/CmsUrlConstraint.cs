using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Routing;

namespace Kaspid.App_Start
{
    public class ValidControllerAction : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            var action = values["action"] as string;
            var controller = values["controller"] as string;
            string first = controller.Substring(0, 1).ToUpper();
            string last = controller.Substring(1, controller.Length - 1);
            controller = first + last;
            var controllerFullName = string.Format("Kaspid.Controllers.{0}Controller", controller);

            var cont = Assembly.GetExecutingAssembly().GetType(controllerFullName);
            return cont != null;
        }
    }
    public class ValidGroupAddress : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            List<string> urls = new List<string> { "services", "product", "news", "article","banner" };
            var action = values["action"] as string;
            var controller = values["controller"] as string;
            if (urls.Contains(controller.ToLower()))
                return true;
            else
                return false;
        }
    }
  
}