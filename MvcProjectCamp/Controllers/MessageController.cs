using BusinessLayer.Concrete;
using BusinessLayer.Validation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager mm = new MessageManager(new EFMessageDal());
        DraftManager dm = new DraftManager(new EFDraftDal());
        MessageValidator mValidator = new MessageValidator();

        public ActionResult Inbox()
        {

            var messageList = mm.GetListInbox();
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            var messageList = mm.GetListSendbox();
            return View(messageList);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult NewMessage(Message message, String draftButton, String sendButton)
        {
            ValidationResult result = mValidator.Validate(message);

            if (!string.IsNullOrEmpty(sendButton))
            {
                if (result.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    mm.MessageAddBL(message);
                    return RedirectToAction("Sendbox");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError(err.PropertyName, err.ErrorMessage);
                    }
                }
            }

            if (!string.IsNullOrEmpty(draftButton))
            {
                Draft _draft = new Draft();
                _draft.DraftMessageContent = message.MessageContent;
                _draft.DraftMessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                _draft.DraftReceiverMail = message.ReceiverMail;
                _draft.DraftSenderMail = message.SenderMail;
                _draft.DraftSubject = message.Subject;
                dm.DraftAddBL(_draft);
                return RedirectToAction("Index","Draft");
            }
            return View();
        }


        public ActionResult GetMessageInboxDetails(int id)
        {
            var values = mm.GetByIDBL(id);
            ViewBag.isRead = values.ReadReceipt;
            return View(values);
        }

        public ActionResult GetMessageSendboxDetails(int id)
        {
            var values = mm.GetByIDBL(id);
            return View(values);
        }

        public ActionResult MessageRead(int id)
        {
            var message = mm.GetByIDBL(id);
            mm.MessageRead(message);

            return RedirectToAction("Inbox");
        }

        public ActionResult MessageNotRead(int id)
        {
            var message = mm.GetByIDBL(id);
            mm.MessageNotRead(message);

            return RedirectToAction("Inbox");
        }

    }

}