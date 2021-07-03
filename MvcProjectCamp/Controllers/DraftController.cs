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
    public class DraftController : Controller
    {
        DraftManager dm = new DraftManager(new EFDraftDal());

        public ActionResult Index()
        {
            var draftValues = dm.GetList();
            return View(draftValues);
        }

        [HttpGet]
        public ActionResult UpdateDraft(int id)
        {
            var draft = dm.GetByIDBL(id);
            return View(draft);
        }

        [HttpPost]
        public ActionResult UpdateDraft(Draft draft)
        {
            dm.DraftUpdate(draft);
            return RedirectToAction("Index");
        }
    }
}