using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolJournal.Helpers
{
    public static class MenuExtensions
    {
        public static bool IsActive(this HtmlHelper html, string controller)
        {
            var routeValues = html.ViewContext.RouteData.Values;
            var currentController = routeValues["controller"].ToString();

            return controller == currentController;
        }
    }
}