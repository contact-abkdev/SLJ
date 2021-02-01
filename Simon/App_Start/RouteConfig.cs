using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Simon
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "contact",
               url: "contact-us",
               defaults: new { controller = "Home", action = "Contact" }
           );

            routes.MapRoute(
              name: "Index",
              url: "homepage",
              defaults: new { controller = "Home", action = "Index" }
          );
            routes.MapRoute(
              name: "about",
              url: "about-us",
              defaults: new { controller = "Home", action = "About" }
          );
            routes.MapRoute(
              name: "services",
              url: "services",
              defaults: new { controller = "Home", action = "Services" }
          );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
