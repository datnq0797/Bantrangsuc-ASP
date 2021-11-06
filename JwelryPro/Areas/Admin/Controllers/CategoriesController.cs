using JwelryPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JwelryPro.Areas.Admin.ViewModel;
using System.IO;
using System.Data.Entity.Validation;

namespace JwelryPro.Areas.Admin.Controllers
{
	public class CategoriesController : BaseController
	{
		// GET: Admin/Categories
		public ActionResult TableSanPham()
		{
			List<SanPhamVM> list = new List<SanPhamVM>();

			using (var context = new SHOP_JEWELRYEntities1())
			{

				var pros = context.PRODUCTS.Include("CATEGORy").ToList();

				foreach (var item in pros)
				{
					list.Add(new SanPhamVM
					{
						cate = item.CATEGORy.NAME_CATE,
						id = item.ID_PRO,
						name = item.NAME,
						price = item.PRICE,
						title = item.TITLE,
						path = item.PATH
					});
				}
			}
			return View(list);
		}

		public ActionResult AddSanPham()
		{
			using (var context = new SHOP_JEWELRYEntities1())
			{
				ViewBag.Cate = context.CATEGORIES.ToList();
			}
			return View();
		}
		[ValidateInput(false)]
		//-----thêm sản phẩm
		public ActionResult ThemSanPham(PRODUCT sanpham)
		{

			try
			{
				using (var context = new SHOP_JEWELRYEntities1())
				{
					var temp = context.PRODUCTS.Where(x => x.NAME.Equals(sanpham.NAME)).Count();
					if (temp > 0)
					{
						return RedirectToAction("TableSanPham");
					}

					PRODUCT product = new PRODUCT();
					product.NAME = sanpham.NAME;
					product.PRICE = sanpham.PRICE;
					product.TITLE = sanpham.TITLE;
					product.SALES = sanpham.SALES;
					product.FAVOR = sanpham.FAVOR;
					product.ID_CATE = sanpham.ID_CATE;
					product.PATH = sanpham.PATH;

					//string fileName = Path.GetFileNameWithoutExtension(sanpham.ImageFile.FileName);
					//string extension = Path.GetExtension(sanpham.ImageFile.FileName);
					//fileName = string.Format("{0}_{1}{2}", sanpham.ID_PRO, fileName, extension);
					//product.PATH = fileName;

					//fileName = Path.Combine(Server.MapPath("~/images/"), fileName);
					//sanpham.ImageFile.SaveAs(fileName);

					context.PRODUCTS.Add(product);
					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				return RedirectToAction("TableSanPham");
			}

			return RedirectToAction("TableSanPham");
		}


		//-----xóa sản phẩm
		public ActionResult DelSanPham(int idpro)
		{
			try
			{
				using (var context = new SHOP_JEWELRYEntities1())
				{
					PRODUCT pro = context.PRODUCTS.Find(idpro);
					context.PRODUCTS.Remove(pro);
					context.SaveChanges();
				}
			}
			catch (Exception ex)
			{
				return Content("Fail");
			}

			return Content("True");
		}

		[ValidateInput(false)]
		//-----hiển thị thông tin sửa sản phẩm
		public ActionResult SuaSanPham(int idpro)
		{
			var pro = new PRODUCT();
			using (var context = new SHOP_JEWELRYEntities1())
			{
				pro = context.PRODUCTS.Find(idpro);
				ViewBag.Cate = context.CATEGORIES.ToList();
			}
			return View(pro);
		}
		[ValidateInput(false)]
		//----sửa sản phẩm
		public ActionResult EditSanPham(PRODUCT pro)
		{
			using (var context = new SHOP_JEWELRYEntities1())
			{
				try
				{
					var find = context.PRODUCTS.Find(pro.ID_PRO);
					find.ID_CATE = pro.ID_CATE;
					find.NAME = pro.NAME;
					find.PATH = pro.PATH;
					find.PRICE = pro.PRICE;
					find.TITLE = pro.TITLE;
					find.SALES = pro.SALES;
					find.FAVOR = pro.FAVOR;
					context.SaveChanges();
				}
				catch(DbEntityValidationException e)
				{
					foreach (var eve in e.EntityValidationErrors)
					{
						Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
							eve.Entry.Entity.GetType().Name, eve.Entry.State);
						foreach (var ve in eve.ValidationErrors)
						{
							Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
								ve.PropertyName, ve.ErrorMessage);
						}
					}
					throw;
				}
				
			}
			return RedirectToAction("TableSanPham");
		}
	}
}