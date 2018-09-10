//-----------------------------------------------------------------------
// <copyright file="RouteConfig.cs" company="GallowayConsulting">
//  RouteConfig
// </copyright>
//-----------------------------------------------------------------------

namespace LabManagementWeb
{
    using System.Web.Mvc;
    using System.Web.Routing;

    /// <summary>
    /// RouteConfig class
    /// </summary>
    public class RouteConfig
    {
        /// <summary>
        /// RegisterRoutes method
        /// </summary>
        /// <param name="routes">Route collection</param>
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional });
        }
    }
}
