using JwelryPro.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JwelryPro.Models;
namespace JwelryPro.Controllers
{
	public class CartController : BaseController
	{




		//----hiển thị card
		public ActionResult ShowCart()
		{
			CartViewModel cartvm = Session["mycart"] as CartViewModel;
			if (cartvm == null)
			{
				return View();
			}
			else
			{
				return View(cartvm);
			}
		}


		//----cập nhật số lượng sản phẩm
		public ActionResult UpdateCart(int idPro, int quantity)
		{
			CartViewModel cartvm = Session["mycart"] as CartViewModel;
			int result = 0;
			if (cartvm != null)
			{
				var pro = cartvm.ListItem.FirstOrDefault(x => x.IdProduct == idPro);
				if (pro != null)
				{
					pro.Quantity = quantity;
				}
				Session["mycart"] = cartvm;

				result = quantity * pro.Price;
			}
			return Content(result.ToString());
		}

		//----tổng tiền 
		public ActionResult TotalCart()
		{
			CartViewModel cartvm = Session["mycart"] as CartViewModel;

			var result = cartvm.ListItem.Sum(x => x.Quantity * x.Price);

			return Content(result.ToString());
		}


		public ActionResult MuaHang()
		{
			return View();
		}

		[HttpPost]
		//----mua hàng
		public ActionResult MuaHang_ThanhToan(CARD card)
		{
			using (var context = new SHOP_JEWELRYEntities1())
			{
				CartViewModel cartVM = Session["mycart"] as CartViewModel;
				var temp = new CARD();
				//----card
				CARD cards = context.CARDS.Where(x => x.NAMES_CUS == card.NAMES_CUS && x.SDT == card.SDT).SingleOrDefault();
				if (cards != null)
				{
					return RedirectToAction("MuaHang");
				}
				else
				{
					CARD ob = new CARD();
					ob.NAMES_CUS = card.NAMES_CUS;
					ob.SDT = card.SDT;
					ob.DIACHI = card.DIACHI;
					ob.EMAIL = card.EMAIL;
					ob.TRANGTHAI = 0;
					ob.TOTAL = cartVM.ListItem.Sum(x => x.Quantity * x.Price);
					context.CARDS.Add(ob);
					context.SaveChanges();
					temp = ob;
				}
				//----card details

				if (cartVM.ListItem.Count() == 0)
				{
					return RedirectToAction("MuaHang");
				}
				else
				{
					foreach (var item in cartVM.ListItem)
					{
						DETAIL_CARDS ob_detail = new DETAIL_CARDS();
						ob_detail.ID_CARDS = temp.ID_CARDS;
						ob_detail.ID_PRO = item.IdProduct;
						ob_detail.QUANTITY = item.Quantity;
						ob_detail.TOTAL_PRICE = item.Price;
						context.DETAIL_CARDS.Add(ob_detail);
						context.SaveChanges();
					}

				}
			}
			Session["mycart"] = null;
			return /*ViewBag.Success("Đặt hàng thành công !!!");*/RedirectToAction("MuaHang");
		}
	}
}

