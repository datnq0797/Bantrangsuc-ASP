using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JwelryPro.Models;
namespace JwelryPro.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Admin/Employee
        public ActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Login(string users,string pass)
		{
			using (var context = new SHOP_JEWELRYEntities1())
			{
				string result = "Fail";
				var emp = context.EMPLOYEES.FirstOrDefault(x => x.USERS == users && x.PASS == pass);
				if (emp != null)
				{
					Session["User"] = emp.USERS;
					result = "Success";
				}
				return Json(result, JsonRequestBehavior.AllowGet);
			}
		}
		public ActionResult Logout()
		{
			Session["User"] = null;
			return RedirectToAction("Login");
			//return View("Login");
		}
	}
}