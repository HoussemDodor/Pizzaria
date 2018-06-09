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
            return View(GetCustomer());
        }

        public ActionResult CustomerDetails()
        {
            return View(GetCustomer());
        }

        [HttpGet]
        public ActionResult EditCustomer()
        {
            return View(GetCustomer());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(Customer c)
        {
            if (ModelState.IsValid)
            {
                if (!customerlogic.CheckIfEmailIsTaken(c.mail))
                {
                    customerlogic.UpdateCustomer(c);
                    return RedirectToAction("CustomerDetails");
                }
                else
                {
                    ModelState.AddModelError("Email", "Deze Email is al bezet");
                    return View(c);
                }
            }

            // Code hoort hier niet te komen, maar als die dat doet reload hij de page
            return View(c);
        }

        public ActionResult OrderListByCustomer()
        {           
            return View(GetCustomer());
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

        private Customer GetCustomer()
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