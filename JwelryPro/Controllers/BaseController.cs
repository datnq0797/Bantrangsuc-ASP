using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JwelryPro.Models;
using JwelryPro.ViewModel;

namespace JwelryPro.Controllers
{
	public class BaseController : Controller
	{
		protected override void OnActionExecuted(ActionExecutedContext filterContext)
		{
			base.OnActionExecuted(filterContext);
			
			List<CATEGORy> listCate = new List<CATEGORy>();
			using (var context = new SHOP_JEWELRYEntities1())
			{
				listCate = context.CATEGORIES.ToList();
			}
			CartViewModel cartVM = Session["mycart"] as CartViewModel;
			filterContext.Controller.ViewBag.CountMyCart = cartVM == null ? 0 : cartVM.ListItem.Count;
			filterContext.Controller.ViewBag.ListCateHeader = listCate;
		}

	}
}