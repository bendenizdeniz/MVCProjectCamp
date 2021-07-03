using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class SkillsController : Controller
    {
        SkillsManager sm = new SkillsManager(new EFSkillsDal());
        public ActionResult Index()
        {
            var skillValue = sm.GetList();
            ViewBag.skillsList = sm.getSkills(skillValue[0]);

            return View(skillValue);
        }
    }
}