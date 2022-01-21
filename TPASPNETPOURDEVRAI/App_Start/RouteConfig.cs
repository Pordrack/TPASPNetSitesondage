using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TPASPNETPOURDEVRAI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Blog",
                url: "Photo/{date}",
                defaults: new { controller = "Photo", action = "AfficherResultat" },
                constraints: new { date = @"(\d{1,2})-(\d{1,2})-(\d{4})" }
            );

            routes.MapRoute(
                name: "Restaurant",
                url: "Restaurant",
                defaults: new { controller = "Restaurant", action = "CreerRestaurant" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );   
        }
    }
}
