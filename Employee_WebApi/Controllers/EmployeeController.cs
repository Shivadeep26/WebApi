using Employee_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Employee_WebApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class EmployeeController : ApiController
    {
        
        public List<Employee> GetEmployees()
        {
            List<Employee> empList = new List<Employee>()
            {
                new Employee{Id=101,Name="A",Location="Z",Salary="100"},
                new Employee{Id=102,Name="B",Location="Y",Salary="101"},
                new Employee{Id=103,Name="C",Location="X",Salary="102"},
                new Employee{Id=104,Name="D",Location="V",Salary="103"}
            };
            return empList;
        }

        public bool Post(Employee emp)
        {
            SqlConnection conn = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;database =ReactDB;Trusted_Connection=True");
            string query = "insert into EmployeeInfo values(@Id,@Name,@Location,@Salary)";
            SqlCommand cmd = new SqlCommand(query,conn);
            cmd.Parameters.Add(new SqlParameter("@Id", emp.Id));
            cmd.Parameters.Add(new SqlParameter("@Name", emp.Name));
            cmd.Parameters.Add(new SqlParameter("@Location", emp.Location));
            cmd.Parameters.Add(new SqlParameter("@Salary", emp.Salary));
            conn.Open();
            int noOfRowsAffected = cmd.ExecuteNonQuery();
            conn.Close();
            return noOfRowsAffected > 0 ? true : false;

        }
    }
}
