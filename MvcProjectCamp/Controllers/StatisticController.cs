using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StatisticController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        WriterManager wm = new WriterManager(new EFWriterDal());


        [HttpGet]
        public ActionResult Index()
        {
            var result = cm.GetList().Count().ToString();
            ViewBag.result = result;

            //var softwareCat = cm.GetList().Where(x => x.CategoryName == "Yazılım");
            var result2 = hm.GetList().Count(x => x.IDCategory == 13);
            ViewBag.result2 = result2;

            var result3 = wm.GetList().Where(x => x.UserName.Contains("a")).Count();
            ViewBag.result3 = result3;

            var result4 = cm.GetList().Where(u => u.IDCategory == hm.GetList().GroupBy(x => x.IDCategory).OrderByDescending(x => x.Count())
                .Select(x => x.Key).FirstOrDefault()).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.result4 = result4;


            var result5 = cm.GetList().Where(x => x.CategoryStatus == true).Count() -
                cm.GetList().Where(x => x.CategoryStatus == false).Count();
            ViewBag.result5 = result5;

            return View();
        }
    }
}