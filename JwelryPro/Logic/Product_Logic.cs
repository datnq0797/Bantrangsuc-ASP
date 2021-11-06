using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JwelryPro.Models;
using PagedList;
namespace JwelryPro.Logic
{
	public class Product_Logic
	{
		/// <summary>
		/// get product sales
		/// </summary>
		/// <returns></returns>
		public List<PRODUCT> GetProductSale()
		{
			List<PRODUCT> listProVM = new List<PRODUCT>();

			// load 6 product sale randoom
			using (var context = new SHOP_JEWELRYEntities1())
			{
				//--Random product :OrderBy(x => Guid.NewGuid())
				var pros = context.PRODUCTS.Where(x => x.SALES.Equals(1)).OrderBy(x => Guid.NewGuid()).ToList().Take(6);

				foreach (var item in pros)
				{
					listProVM.Add(new PRODUCT
					{
						ID_PRO = item.ID_PRO,
						NAME = item.NAME,
						PRICE = item.PRICE,
						TITLE = item.TITLE,
						PATH = item.PATH
					});
				}
			}
			return listProVM;
		}


		/// <summary>
		/// get product favorite
		/// </summary>
		/// <returns></returns>
		public List<PRODUCT> GetProductFavorite()
		{
			List<PRODUCT> listProVM = new List<PRODUCT>();

			// load 6 product farvorite
			using (var context = new SHOP_JEWELRYEntities1())
			{

				var pros = context.PRODUCTS.OrderByDescending(x => x.FAVOR).Take(6);

				foreach (var item in pros)
				{
					listProVM.Add(new PRODUCT
					{
						ID_PRO = item.ID_PRO,
						NAME = item.NAME,
						PRICE = item.PRICE,
						TITLE = item.TITLE,
						PATH = item.PATH
					});
				}
			}
			return listProVM;
		}


		/// <summary>
		/// get product by category
		/// </summary>
		/// <param name="idcate"></param>
		/// <returns></returns>
		public List<PRODUCT> GetProductsByCate(int idcate,ref int totalRecord,int pageIndex=1,int pageSize=6)
		{
			
			List<PRODUCT> listProVM = new List<PRODUCT>();

			// load product by cate
			using (var context = new SHOP_JEWELRYEntities1())
			{
				totalRecord = context.PRODUCTS.Where(x => x.ID_CATE == idcate).Count();
				listProVM = context.PRODUCTS.Where(x => x.ID_CATE == idcate).OrderBy(x => x.ID_CATE).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
			}
			return listProVM;
		}


		//--lấy sản phẩm theo ID_PRO
		public PRODUCT GetProductById(int id_pro)
		{
			PRODUCT pro = new PRODUCT();
			// load product by cate
			using (var context = new SHOP_JEWELRYEntities1())
			{
				pro = context.PRODUCTS.Where(x => x.ID_PRO == id_pro).SingleOrDefault();
			}
			return pro;
		}


		//----Lấy sản phẩm liên quan
		public List<PRODUCT> GetProductRelated(int id_pro)
		{
			List<PRODUCT> listpro = new List<PRODUCT>();
			var pro = GetProductById(id_pro);
			using (var context = new SHOP_JEWELRYEntities1())
			{
				listpro = context.PRODUCTS.Where(x => x.ID_CATE == pro.ID_CATE).ToList();
			}
			return listpro;
		}


	}
}