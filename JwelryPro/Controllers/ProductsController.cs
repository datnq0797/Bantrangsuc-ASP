using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JwelryPro.Logic;
using JwelryPro.Models;

namespace JwelryPro.Controllers
{
	public class ProductsController : BaseController
	{
		// GET: Productsss
		public ActionResult Products(int idCate, int pageIndex = 1, int pageSize =6)
		{
			int totalRecord = 0;

			Product_Logic pro = new Product_Logic();
			
			var model = pro.GetProductsByCate(idCate,ref totalRecord, pageIndex, pageSize);

			ViewBag.Total = totalRecord;
			ViewBag.Page = pageIndex;
			ViewBag.TheLoai = idCate;

			int maxPage = 5;
			int totalPage = 0;
			double tam = totalRecord / pageSize;
			if (totalRecord % pageSize == 0)
			{
				totalPage = (int)tam;
			}
			else
			{
				totalPage = (int)tam + 1;
			}		
			ViewBag.TotalPage = totalPage;
			ViewBag.MaxPage = maxPage;
			ViewBag.First = 1;
			ViewBag.Next = pageIndex + 1;
			ViewBag.Prev = pageIndex - 1;
			ViewBag.Last = totalPage;
			return View(model);


			
		}

		//----chi tiết sản phẩm
		public ActionResult ProductDetails(int idPro)
		{
			Product_Logic pro = new Product_Logic();
			//--two model in one view 
			ViewBag.Detail = pro.GetProductById(idPro);
			ViewBag.Related = pro.GetProductRelated(idPro);
			return View();
		}




	}
}