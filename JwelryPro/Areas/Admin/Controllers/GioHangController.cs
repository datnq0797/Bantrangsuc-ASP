using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JwelryPro.Models;
namespace JwelryPro.Areas.Admin.Controllers
{
	public class GioHangController : Controller
	{
		// GET: Admin/LoaiSP
		public ActionResult Create()
		{
			return View();
		}
		// GET: Admin/GioHang
		public ActionResult ListGH()
		{
			List<CARD> list = new List<CARD>();

			using (var context = new SHOP_JEWELRYEntities1())
			{

				var pros = context.CARDS.ToList();

				foreach (var item in pros)
				{
					list.Add(new CARD
					{
						ID_CARDS = item.ID_CARDS,
						TOTAL = item.TOTAL,
						EMAIL = item.EMAIL,
						DIACHI = item.DIACHI,
						NAMES_CUS = item.NAMES_CUS,
						TRANGTHAI = item.TRANGTHAI,
						SDT = item.SDT
					});
				}
			}
			return View(list);
		}

		public ActionResult Delete(int id)
		{
			using (var context = new SHOP_JEWELRYEntities1())
			{
				var ob = context.DETAIL_CARDS.Find(id);
				if (ob == null)
				{
					var ob2 = context.CARDS.Find(id);
					context.CARDS.Remove(ob2);
					context.SaveChanges();
				}
				else
				{
					foreach(var item in context.DETAIL_CARDS)
					{
						if(item.ID_CARDS == id)
						{
							context.DETAIL_CARDS.Remove(item);
						}
					}
					var ob2 = context.CARDS.Find(id);
					context.CARDS.Remove(ob2);
					context.SaveChanges();
				}
			}
			return RedirectToAction("ListGH");
		}

		public ActionResult Details(int id)
		{
			List<DETAIL_CARDS> list = new List<DETAIL_CARDS>();

			using (var context = new SHOP_JEWELRYEntities1())
			{

				var pros = context.DETAIL_CARDS.Where(x => x.ID_CARDS.Equals(id));
				if(pros.Count() == 0)
				{
					return RedirectToAction("ListGH");
				}
				else
				{
					foreach(var item in pros)
					{
						list.Add(new DETAIL_CARDS
						{
							ID_DETAIL_CARDS = item.ID_DETAIL_CARDS,
							ID_PRO = item.ID_PRO,
							ID_CARDS = item.ID_CARDS,
							QUANTITY = item.QUANTITY,
							TOTAL_PRICE = item.TOTAL_PRICE,

						});
					}
					
				}
				
			}
			return View(list);
		}

		public ActionResult CreateThem(CARD card)
		{

			using (var context = new SHOP_JEWELRYEntities1())
			{
				var temp = context.CARDS.Where(x => x.ID_CARDS.Equals(card.ID_CARDS)).Count();

				CARD ca = new CARD();
				ca.ID_CARDS = card.ID_CARDS;
				ca.TOTAL = card.TOTAL;
				ca.EMAIL = card.EMAIL;
				ca.DIACHI = card.DIACHI;
				ca.NAMES_CUS = card.NAMES_CUS;
				ca.TRANGTHAI = card.TRANGTHAI;
				ca.SDT = card.SDT;
				context.CARDS.Add(ca);
				context.SaveChanges();
				return RedirectToAction("ListGH", "GioHang");
			}
		}

		//----EDIT
		public ActionResult Edit(int id)
		{

			using (var context = new SHOP_JEWELRYEntities1())
			{
				
					var card = context.CARDS.Find(id);
					return View(card);


			}
			
		}
		public ActionResult EditSua(CARD ca)
		{
			using (var context = new SHOP_JEWELRYEntities1())
			{
				var card = context.CARDS.Find(ca.ID_CARDS);
				card.NAMES_CUS = ca.NAMES_CUS;
				card.SDT = ca.SDT;
				card.DIACHI = ca.DIACHI;
				card.EMAIL = ca.EMAIL;
				card.TOTAL = ca.TOTAL;
				card.TRANGTHAI = ca.TRANGTHAI;
				context.SaveChanges();
			}
			return RedirectToAction("ListGH", "GioHang");
		}

		//--EDIT DETAIL
		public ActionResult EditDetail(int id)
		{
			
			using (var context = new SHOP_JEWELRYEntities1())
			{
				
				var card = context.DETAIL_CARDS.Find(id);
				ViewBag.SanPham = context.PRODUCTS.ToList() ;
				ViewBag.Cards = context.CARDS.ToList();
				return View(card);
			}

		}

		public ActionResult EditDetail_Sua(DETAIL_CARDS ca)
		{
			using (var context = new SHOP_JEWELRYEntities1())
			{
				var card = context.DETAIL_CARDS.Find(ca.ID_DETAIL_CARDS);
				card.ID_PRO = ca.ID_PRO;
				card.QUANTITY = ca.QUANTITY;
				card.TOTAL_PRICE = ca.TOTAL_PRICE;

				context.SaveChanges();
			}
			return RedirectToAction("ListGH", "GioHang");
		}

		//--DELETE DETAIL

	}
}