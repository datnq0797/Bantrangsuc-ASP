using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JwelryPro.Models;
using JwelryPro.Logic;
using JwelryPro.ViewModel;
namespace JwelryPro.Controllers
{
	public class HomeController : BaseController
	{
		public ActionResult Index()
		{
			Product_Logic pro = new Product_Logic();
			//--two model in one view 
			ViewBag.Sales= pro.GetProductSale();
			ViewBag.Favors = pro.GetProductFavorite();
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult AddCart(int idPro, string namePro, int pricePro,string pathPro,string detailPro)
		{
			CartViewModel cartvm = Session["mycart"] as CartViewModel;
			if (cartvm == null)
			{
				cartvm = new CartViewModel();
				cartvm.ListItem.Add(new CartItemViewModel { IdProduct = idPro, Quantity = 1, NamePro = namePro, Price = pricePro ,Path = pathPro,Detail = detailPro });
				Session["mycart"] = cartvm;
				return Content(cartvm.ListItem.Count.ToString());
			}
			else
			{
				//var pro = cartvm.ListItem.Where(x => x.IdProduct == idPro).FirstOrDefault();
				var pro = cartvm.ListItem.FirstOrDefault(x => x.IdProduct == idPro);
				if (pro == null)
				{
					cartvm.ListItem.Add(new CartItemViewModel { IdProduct = idPro, Quantity = 1, NamePro = namePro, Price = pricePro, Path = pathPro, Detail = detailPro });
				}
				else
				{
					pro.Quantity += 1;
				}

				Session["mycart"] = cartvm;
				//return Content(cartvm.ListItem.Count.ToString());
				return Json(cartvm.ListItem.Count.ToString(), JsonRequestBehavior.AllowGet);
			}
		}

		public ActionResult DelCart(int idPro)
		{
			var cartvm = Session["mycart"] as CartViewModel;
			if (cartvm == null)
			{
				return Content("0");
			}
			else
			{
				
				var pro = cartvm.ListItem.FirstOrDefault(x => x.IdProduct == idPro);
				if (pro != null)
				{
					cartvm.ListItem.RemoveAll(x=>x.IdProduct == idPro);
				}
				Session["mycart"] = cartvm;			
				return Content("1");
			}
		}

	}
}