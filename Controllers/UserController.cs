using MyProject1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject1.Controllers
{
    public class UserController : Controller
    {
        private readonly Configuration Configuration;
        private String connectionString;
        SqlOperation sqlOperation = new SqlOperation();
        public UserController()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["Connection"];
            connectionString = settings.ConnectionString;
        }
        // GET: Admin
        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult ViewEmployees()
        {
            return View(sqlOperation.ViewEmployee(connectionString));
        }

        //Initial Add Employee
        [HttpGet]
        public ActionResult AddEmployee()
        {
            sqlOperation.Title(connectionString);
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(AddEmployeeModel addEmployeeModel)
        {
            if (ModelState.IsValid && sqlOperation.AddEmployee(addEmployeeModel, connectionString))
            {
                return View("Welcome");
            }
            return View();
        }

        // Update Employee Initial

        public List<string> OldData = new List<string>();
        public List<string> NewData = new List<string>();
        public ActionResult UpdateEmployeeForm(int Id)
        {
            UpdateEmployeeModel.EmployeeID = Id;
            OldData = sqlOperation.GetDetails(Id, connectionString);
            TempData["LastName"] = OldData[0];
            TempData["FirstName"] = OldData[1];
            TempData["Title"] = OldData[2];
            TempData["TitleOfCourtesy"] = OldData[3];
            TempData["BirthDate"] = OldData[4];
            TempData["Address"] = OldData[5];
            TempData["City"] = OldData[6];
            TempData["Country"] = OldData[7];
            TempData["HomePhone"] = OldData[8];
            return View("UpdateEmployee");
        }

        [HttpGet]
        public ActionResult UpdateEmployee()
        {
            return View();
        }

        //Validate Employee Details
        [HttpPost]
        public ActionResult UpdateEmployee(UpdateEmployeeModel updateEmployeeModel)
        {
            if (ModelState.IsValid)
            {
                NewData.Add(updateEmployeeModel.LastName);
                NewData.Add(updateEmployeeModel.FirstName);
                NewData.Add(updateEmployeeModel.Title);
                NewData.Add(updateEmployeeModel.TitleOfCourtesy);
                NewData.Add((updateEmployeeModel.BirthDate).ToString());
                NewData.Add(updateEmployeeModel.Address);
                NewData.Add(updateEmployeeModel.City);
                NewData.Add(updateEmployeeModel.Country);
                NewData.Add((updateEmployeeModel.HomePhone).ToString());
                OldData = sqlOperation.GetDetails(UpdateEmployeeModel.EmployeeID, connectionString);
                for (int i = 0; i < 9; i++)
                {
                    if (OldData[i] != NewData[i])
                    {
                        sqlOperation.UpdateEmployee(i, NewData[i], connectionString);
                    }
                }
                return View("Welcome");
            }
            return View();
        }


        public ActionResult DeleteEmployee(string Id)
        {
            string[] id = Id.Split(',');
            foreach (string item in id)
            {
                sqlOperation.DeleteEmployee(Convert.ToInt32(item), connectionString);
            }
            return View("Welcome");
        }
    }
}