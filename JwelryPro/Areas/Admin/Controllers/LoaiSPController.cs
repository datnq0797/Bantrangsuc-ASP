using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JwelryPro.Models;
namespace JwelryPro.Areas.Admin.Controllers
{
    public class LoaiSPController : Controller
    {
        // GET: Admin/LoaiSP
        public ActionResult Create()
        {
            return View();
        }

		public ActionResult CreateThem(CATEGORy cate)
		{
			
			using (var context = new SHOP_JEWELRYEntities1())
			{
				var temp = context.PRODUCTS.Where(x => x.NAME.Equals(cate.NAME_CATE)).Count();				

				CATEGORy ca = new CATEGORy();
				ca.NAME_CATE = cate.NAME_CATE;
				context.CATEGORIES.Add(ca);
				context.SaveChanges();
				return RedirectToAction("TableCate","LoaiSP");
			}
		}


		public ActionResult TableCate()
		{
			List<CATEGORy> list = new List<CATEGORy>();

			using (var context = new SHOP_JEWELRYEntities1())
			{

				var pros = context.CATEGORIES.ToList();

				foreach (var item in pros)
				{
					list.Add(new CATEGORy
					{
						ID_CATE = item.ID_CATE,
						NAME_CATE = item.NAME_CATE
					});
				}
			}
			return View(list);
		}


		public ActionResult Delete(int id)
		{
			using (var context = new SHOP_JEWELRYEntities1())
			{
				try
				{
					var cate = context.CATEGORIES.Find(id);			
					context.CATEGORIES.Remove(cate);
					context.SaveChanges();
				}
				catch (Exception)
				{
					
				}
				
			}
			return RedirectToAction("TableCate");
		}

		public ActionResult Edit(int id)
		{

			using (var context = new SHOP_JEWELRYEntities1())
			{
				try
				{
					var cate = context.CATEGORIES.Find(id);
					return View(cate);

				}
				catch (Exception)
				{

				}

			}
			return View();
		}
		public ActionResult EditSua(CATEGORy nameCate)
		{
			using (var context = new SHOP_JEWELRYEntities1())
			{
				var cate = context.CATEGORIES.Find(nameCate.ID_CATE);
				cate.NAME_CATE = nameCate.NAME_CATE;
				context.SaveChanges();
			}
			return RedirectToAction("TableCate", "LoaiSP");
		}
	}
}