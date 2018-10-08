using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationDatabase;

namespace PublicTransport.Controllers
{
    public class LoginPannelController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
            //if (TempData["Logged"] != null && TempData["Logged"].Equals(true))
            //{
            //    return View();
            //}
            //else
            //{
            //    return RedirectToAction("Index", "Home", new { area = "" });
            //}
        }
        
        [HttpPost]
        public JsonResult VerifyCredentials(string login, string password)
        {
            //var model = new ApplicationDatabase.ResultData.OpUser_Result();
            if (login.Contains("a"))
            {
                TempData["Logged"] = true;
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                TempData["Logged"] = false;
                return Json("failure", JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult ReportProblem()
        {
            return PartialView("ReportProblem");
        }

        [HttpPost]
        public ActionResult Contact()
        {
            return PartialView("MyPage");
        }

        [HttpGet]
        public JsonResult Test()
        {
            return Json("TestMSG", JsonRequestBehavior.AllowGet);
        }
    }
}
