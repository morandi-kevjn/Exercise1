using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Exercise1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /* 
             * parameters: 1 routes name, 2 url path, 3 Anomnymous object, it is a controller, 4 
             */
            /*
            routes.MapRoute(
                "MoviesByRealeaseDate",
                "movies/released/{year}/{month}",
                new { controller = "Movies", action = "ByReleaseDate" },
                //new { year = @"\d{4}", month = @"\d{2"} // se voglio 4 digit per l'anno e 2 per il mese
                new { year = @"2015|2016", month = @"\d{2" } // rendere più specifico il CustomRoute, come dovrebbe essere
            );
            */
            // New Solution
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
