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
            if (id != null)
            {
                return View(orderLogic.GetOrderByID((int)id));
            }
            else
            {
                Order order = new Order()
                {
                    CustomerID = GetCustomer().ID
                };
                return View(order);
            }       
        }

        public ActionResult NewPizza()
        {
            return View();
        }

        public ActionResult StandardPizzaList(int? id)
        {
            ViewBag.OrderID = id;
            return View(productlogic.GetAllPizzas());
        }

        [HttpPost]
        public ActionResult StandardPizzaList(Pizza pizza)
        {
            productlogic.AddPizzaToOrder(ViewBag.OrderID, pizza.ID);
            RedirectToAction("Index", new { id = ViewBag.OrderID });
        }

        public ActionResult SidesList()
        {
            return View(productlogic.GetAllSides());
        }

        public ActionResult OrderPlaced()
        {
            return View();
        }

        private Customer GetCustomer()
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