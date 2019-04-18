using System;
using System.Diagnostics;
using System.Web.Mvc;
using System.Web.Routing;

//OutputCache: caches the output of a controller action for a specified amount of time
//HandleError: handles errors raised when a controller action executes
//Authorize: enables you to restrict access to a particular user or role 
namespace MvcApplication1.ActionFilters
{
     public class LogActionFilter : ActionFilterAttribute

     {
          public override void OnActionExecuting(ActionExecutingContext filterContext)
          {
               Log("OnActionExecuting", filterContext.RouteData);       
          }

          public override void OnActionExecuted(ActionExecutedContext filterContext)
          {
               Log("OnActionExecuted", filterContext.RouteData);       
          }

          public override void OnResultExecuting(ResultExecutingContext filterContext)
          {
               Log("OnResultExecuting", filterContext.RouteData);       
          }

          public override void OnResultExecuted(ResultExecutedContext filterContext)
          {
               Log("OnResultExecuted", filterContext.RouteData);       
          }


          private void Log(string methodName, RouteData routeData)
          {
               var controllerName = routeData.Values["controller"];
               var actionName = routeData.Values["action"];
               var message = String.Format("{0} controller:{1} action:{2}", methodName, controllerName, actionName);
               Debug.WriteLine(message, "Action Filter Log");
          }

     }
}