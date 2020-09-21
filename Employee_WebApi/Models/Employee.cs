using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee_WebApi.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string  Salary { get; set; }
    }
}