using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NTierProject.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "RecipeDetail",
              url: "Recipe/RecipeDetail/{slug}",
              defaults: new { controller = "Recipe", action = "RecipeDetail", slug = "" },
              namespaces: new[] { "TarifDefterim.UI.Controllers" } // Area içerisindeki aynı isimdeki controller ile çakışmaması için kullanıyoruz.
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "NTierProject.UI.Controllers" }
            );
        }
    }
}
