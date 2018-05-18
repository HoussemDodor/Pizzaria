using System;
using System.Web.Mvc;
using LogicLayer;
using Models;

namespace PizzariaWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private CustomerLogic customerlogic = new CustomerLogic();

        public ActionResult Index()
        {
            return View(customer());
        }

        public ActionResult CustomerDetails()
        {
            return View(customer());
        }

        public ActionResult EditCustomer()
        {
            return View(customer());
        }

        public ActionResult OrderListByCustomer()
        {           
            return View(customer());
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }

        private Customer customer()
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
    }
}