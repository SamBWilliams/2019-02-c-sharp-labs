using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Diagnostics;

namespace ASP_Controllers.Controllers
{
    public class TestingFilters : ActionFilterAttribute
    {
        private void LoggingMethod(RouteData rd)
        {
            var controller = rd.Values["controller"];
            var action = rd.Values["action"];
            string message = string.Format("Controller: {0}: Action: {1}",controller, action);
            Debug.Write(message);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LoggingMethod(filterContext.RouteData);
        }
    }
}