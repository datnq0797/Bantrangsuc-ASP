using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JwelryPro.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
		// GET: Admin/Base

		protected override void OnResultExecuting(ResultExecutingContext filterContext)
		{
			base.OnResultExecuting(filterContext);

			if (Session["User"] == null)
			{
				// return login
				filterContext.Result = new RedirectToRouteResult(
					   new RouteValueDictionary(new { controller = "Employee", action = "Login" }));
				filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
			}
		}
	}
}