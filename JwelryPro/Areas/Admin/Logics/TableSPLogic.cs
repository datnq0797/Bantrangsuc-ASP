using JwelryPro.Areas.Admin.ViewModel;
using JwelryPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JwelryPro.Areas.Admin.Logics
{
	public class TableSPLogic
	{
		public List<SanPhamVM> danhsach_SP()
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
			return list;
		}

		


	}
}