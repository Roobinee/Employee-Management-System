using MyProject1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using MyProject1.Controllers;
using MyProject1.Models;

namespace MyProject1
{
    public class SqlOperation
    {
        public bool LoginSql(LoginModel loginModel, string connectionString)
        {
            string QueryString = "Exec Employee_Details";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(QueryString, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if ((reader[1].ToString() == loginModel.UserName) && (reader[2].ToString() == loginModel.Password))
                        {
                            // ViewBag.display += reader[1];
                            return true;
                        }
                    }
                    reader.Close();
                    // ViewBag.error = "Invalid UserName and Password";
                    return false;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            // ViewBag.error = "Invalid UserName and Password";
        }

        public List<ViewEmployeeModel> ViewEmployee(string connectionString)
        {
            List<ViewEmployeeModel> EmployeeTable = new List<ViewEmployeeModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("exec Employee_Details", connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        EmployeeTable.Add(new ViewEmployeeModel
                        {
                            EmployeeID = Convert.ToInt32(reader[0]),
                            FirstName = reader[1].ToString(),
                            LastName = reader[2].ToString(),
                            Title = reader[3].ToString(),
                            TitleOfCourtesy = reader[4].ToString(),
                            BirthDate = reader[5].ToString(),
                            Address = reader[6].ToString(),
                            City = reader[7].ToString(),
                            Country = reader[8].ToString(),
                            HomePhone = reader[9].ToString()
                        });
                    }
                    reader.Close();
                }
                catch (Exception)
                {

                }
            }
            return EmployeeTable;
        }

        public bool AddEmployee(AddEmployeeModel addEmployeeModel, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("Details_Employees", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter() { ParameterName = "@FirstName", Value = addEmployeeModel.FirstName };
                command.Parameters.Add(param);
                param = new SqlParameter() { ParameterName = "@LastName", Value = addEmployeeModel.LastName };
                command.Parameters.Add(param);
                param = new SqlParameter() { ParameterName = "@Title", Value = addEmployeeModel.Title };
                command.Parameters.Add(param);
                param = new SqlParameter() { ParameterName = "@TitleOfCourtesy", Value = addEmployeeModel.TitleOfCourtesy };
                command.Parameters.Add(param);
                param = new SqlParameter() { ParameterName = "@BirthDate", Value = addEmployeeModel.BirthDate };
                command.Parameters.Add(param);
                param = new SqlParameter() { ParameterName = "@Address", Value = addEmployeeModel.Address };
                command.Parameters.Add(param);
                param = new SqlParameter() { ParameterName = "@City", Value = addEmployeeModel.City };
                command.Parameters.Add(param);
                param = new SqlParameter() { ParameterName = "@Country", Value = addEmployeeModel.Country };
                command.Parameters.Add(param);
                param = new SqlParameter() { ParameterName = "@HomePhone", Value = addEmployeeModel.HomePhone };
                command.Parameters.Add(param);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                }
            }
            return true;
        }

        public string UpdateEmployee(int Column, string Value, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("UpdateModifiedData", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter() { ParameterName = "@EmployeeID", Value = UpdateEmployeeModel.EmployeeID };
                command.Parameters.Add(param);
                param = new SqlParameter() { ParameterName = "@Column", Value = Column };
                command.Parameters.Add(param);
                param = new SqlParameter() { ParameterName = "@Value", Value = Value };
                command.Parameters.Add(param);
                connection.Open();
                command.ExecuteNonQuery();
                string[] Update = new string[] { "LastName", "FirstName", "Title", "TitleOfCourtesy", "BirthDate", "Address", "City", "Country", "HomePhone" };
                return Update[Column];
            }
        }

        public List<string> GetDetails(int employeeID, string connectionString)
        {
            List<string> EmployeeDetails = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select LastName,FirstName,Title,TitleOfCourtesy,BirthDate,Address,City,Country,HomePhone from Employees where EmployeeID=" + employeeID, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    EmployeeDetails.Add(reader[0].ToString());
                    EmployeeDetails.Add(reader[1].ToString());
                    EmployeeDetails.Add(reader[2].ToString());
                    EmployeeDetails.Add(reader[3].ToString());
                    EmployeeDetails.Add(reader[4].ToString());
                    EmployeeDetails.Add(reader[5].ToString());
                    EmployeeDetails.Add(reader[6].ToString());
                    EmployeeDetails.Add(reader[7].ToString());
                    EmployeeDetails.Add(reader[8].ToString());
                }
                reader.Close();
            }
            return EmployeeDetails;
        }

        public void Title(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("select Title from [dbo].[Emp_Title]", connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (AddEmployeeModel.TitleList.Contains(reader[0].ToString()) == false)
                    {
                        AddEmployeeModel.TitleList.Add(reader[0].ToString());
                    }
                }
                reader.Close();
            }
        }



        public bool DeleteEmployee(int Id, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand("DeleteEmployees", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter() { ParameterName = "@EmployeeID", Value = Id };
                command.Parameters.Add(param);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }
    }
}