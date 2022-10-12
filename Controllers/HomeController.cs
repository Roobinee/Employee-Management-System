using MyProject1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject1.Controllers
{
    public class HomeController : Controller
    {
        private readonly Configuration Configuration;
        private String connectionString;

        public HomeController()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Connection"];
            connectionString = settings.ConnectionString;
        }
        public ActionResult Index()
        {
            return View();
        }

        SqlOperation sqlOperation = new SqlOperation();

        //Intial Login 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Validated Login
        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (ModelState.IsValid && sqlOperation.LoginSql(loginModel, connectionString))
            {
                return View("../User/Welcome");
            }
            return View();
        }

        //public actionresult about()
        //{
        //    viewbag.message = "your application description page.";

        //    return view();
        //}

        //public actionresult contact()
        //{
        //    viewbag.message = "your contact page.";

        //    return view();
        //}
    }
}