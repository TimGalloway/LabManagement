//-----------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="GallowayConsulting">
//  FilterConfig
// </copyright>
//-----------------------------------------------------------------------

namespace LabManagementWeb
{
    using System.Web.Mvc;

    /// <summary>
    /// FilterConfig class
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// RegisterGlobalFilters method
        /// </summary>
        /// <param name="filters">GlobalFilter collection</param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
