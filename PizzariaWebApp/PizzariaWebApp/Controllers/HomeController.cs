using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using LogicLayer;
using Models;

namespace PizzariaWebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private CustomerLogic customerlogic = new CustomerLogic();
        Customer customer;

        public ActionResult Index()
        {
            if (GetLoggedUserID() == 0) { return RedirectToAction("Login", "Account"); }
            customer = customerlogic.GetCustomerByID(GetLoggedUserID());
            return View(customer);
        }

        [AllowAnonymous]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CustomerDetails()
        {
            if (GetLoggedUserID() == 0) { return RedirectToAction("Login", "Account"); }
            customer = customerlogic.GetCustomerByID(GetLoggedUserID());
            return View(customer);
        }

        public ActionResult EditCustomer()
        {
            if (GetLoggedUserID() == 0) { return RedirectToAction("Login", "Account"); }
            customer = customerlogic.GetCustomerByID(GetLoggedUserID());
            return View(customer);
        }

        public ActionResult OrderListByCustomer()
        {
            if (GetLoggedUserID() == 0) { return RedirectToAction("Login", "Account"); }
            customer = customerlogic.GetCustomerByID(GetLoggedUserID());
            return View(customer.OrdersByCustomer);
        }

        private int GetLoggedUserID()
        {
            int userID = 0;
            // GET: id van ingelogde gebruiker
            string a = Request.Cookies["UserCookie"].Values["User_ID"];

            // Convert de string naar een int als het mogelijk is, zoniet bad request
            try { userID = Convert.ToInt32(a); }
            catch { userID = 0; }

            return userID;
        }
    }
}