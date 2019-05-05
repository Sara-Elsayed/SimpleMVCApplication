using SimpleAuthProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleAuthProject.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Department> Departments { get; set; }
    }
}