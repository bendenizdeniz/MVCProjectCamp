using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class AboutController : Controller
    {
        AboutManager abm = new AboutManager(new EFAboutDal());

        public ActionResult Index()
        {
            ViewBag.activeAbout = abm.GetList().FirstOrDefault(x => x.Status == true);
            var aboutValues = abm.GetList();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            var aboutValues = abm.GetList();
            return View(aboutValues);
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            abm.AboutAddBL(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

        public ActionResult AboutActive(int id)
        {
            var aboutValue = abm.GetByIDBL(id);
            aboutValue.Status = true;
            abm.AboutUpdate(aboutValue);
            return RedirectToAction("Index");
        }

        public ActionResult AboutPassive(int id)
        {
            var aboutValue = abm.GetByIDBL(id);
            aboutValue.Status = false;
            abm.AboutUpdate(aboutValue);
            return RedirectToAction("Index");
        }
    }
}