using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer;
using Models;

namespace PizzariaWebApp.Controllers
{
    public class OrderController : Controller
    {
        PizzaLogic pizzaLogic = new PizzaLogic();
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
            return View(pizzaLogic.GetAllPizzas());
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