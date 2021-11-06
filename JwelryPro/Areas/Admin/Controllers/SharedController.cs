using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JwelryPro.Models;
namespace JwelryPro.Areas.Admin.Controllers
{
    public class SharedController : Controller
    {
        // GET: Admin/Shared
        public ActionResult _Layout()
        {
			List<CATEGORy> list = new List<CATEGORy>();

			using (var context = new SHOP_JEWELRYEntities1())
			{

				list = context.CATEGORIES.ToList();

				
			}
			return View(list);
			
        }
    }
}