using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PublicTransport.SignalR;
using ApplicationDatabase.DataServices;
using ApplicationDatabase.Interfaces;

namespace PublicTransport.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale 
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTariffTickets(string type, int zone, bool student, bool resident, bool parking)
        {
            IDataService _dataService = new DataService();
            return Json(_dataService.GetTariffTickets(type, zone, student, resident, parking), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetParkingTickets(string type, bool resident)
        {
            IDataService _dataService = new DataService();
            return Json(_dataService.GetParkingTickets(type, resident), JsonRequestBehavior.AllowGet);
        }
    }
}