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
        ProductLogic productlogic = new ProductLogic();
        CustomerLogic customerlogic = new CustomerLogic();
        OrderLogic orderLogic = new OrderLogic();

        public ActionResult Index(int? id)
        {            
            if (ViewBag.Order == null)
            {
                ViewBag.Order = new Order() { CustomerID = GetCurrentCustomer().ID, Customer = GetCurrentCustomer() };
            }
            return View(ViewBag.Order);
        }

        public ActionResult NewPizza()
        {
            return View();
        }

        public ActionResult StandardPizzaList()
        {
            return View(productlogic.GetAllPizzas());
        }

        [HttpPost]
        public ActionResult StandardPizzaList(int pizzaID)
        {
            productlogic.AddPizzaToOrder(ViewBag.Order.ID, pizzaID);
            return RedirectToAction("Index", new { id = ViewBag.OrderID });
        }

        public ActionResult SidesList()
        {
            return View(productlogic.GetAllSides());
        }

        public ActionResult OrderPlaced()
        {
            return View();
        }

        private Customer GetCurrentCustomer()
        {
            try
            {
                int userID = 0;
                // GET: id van ingelogde gebruiker
                string a = Request.Cookies["UserCookie"].Values["User_ID"];

                // Convert de id van een string naar een int.
                try { userID = Convert.ToInt32(a); }
                catch { userID = 0; }

                //haal de customer op uit de database
                Customer x = customerlogic.GetCustomerByID(userID);

                return x;
            }
            catch
            {
                return null;
            }
        }
    }
}