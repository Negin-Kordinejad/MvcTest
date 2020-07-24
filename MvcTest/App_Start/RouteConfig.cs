using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcTest
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //  name: "Movie",
            //  url: "{controller}/{action}/{year}/{month}",
            //  defaults: new { controller = "Movies", action = "Random" },
            //  constraints: new { year = @"\d{4}", month = @"\d{2}" });

            routes.MapRoute(
              name: "Movie",
              url: "{controller}",
              defaults: new { controller = "Movies", action = "Index" }
              );

            routes.MapRoute(
               name: "Address",
               url: "{controller}/{action}",
               defaults: new { controller = "Address", action = "create" }
           );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Meal",
               url: "{controller}/{action}",
               defaults: new { controller = "Meal", action = "Layout" }
           );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
