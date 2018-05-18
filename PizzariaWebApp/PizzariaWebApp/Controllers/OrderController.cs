using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzariaWebApp.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NewPizza()
        {
            return View();
        }

        public ActionResult StandardPizzaList()
        {
            return View();
        }

        public ActionResult SidesList()
        {
            return View();
        }

        public ActionResult OrderPlaced()
        {
            return View();
        }
    }
}