using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class LoginController : Controller
    {
        AdminManager adm = new AdminManager(new EFAdminDal());

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var _admin = adm.AdminLogin(admin);
            if (_admin != null)
            {
                FormsAuthentication.SetAuthCookie(_admin.AdminUserName, false);
                Session["AdminUserName"] = _admin.AdminUserName;
                TempData["partial"] = "false";
                return RedirectToAction("Index", "AdminCategory");
            }
            else if (_admin == null)
            {
                TempData["partial"] = "true";
                return RedirectToAction("Index");

            }
            return View();
        }

        public PartialViewResult LoginPartial()
        {
            return PartialView();
        }
    }
}