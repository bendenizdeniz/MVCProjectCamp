using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EFContactDal());
        MessageManager mm = new MessageManager(new EFMessageDal());
        DraftManager dm = new DraftManager(new EFDraftDal());

        ContactValidator cv = new ContactValidator();

        public ActionResult Index()
        {
            var contactValues = cm.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactDetail = cm.GetByID(id);
            return View(contactDetail);
        }

        public PartialViewResult MailPartial()
        {
            ViewBag.Contact = cm.GetList().Count();
            ViewBag.MessageInbox = mm.GetListInbox().Where(x => x.ReadReceipt == false).Count();
            ViewBag.MessageSendBox = mm.GetListSendbox().Count();
            ViewBag.DraftCount = dm.GetList().Count();
            return PartialView();
        }
    }
}