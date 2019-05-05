using SimpleAuthProject.Models;
using SimpleAuthProject.Models.Entities;
using SimpleAuthProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using System.Threading.Tasks;

namespace SimpleAuthProject.Controllers
{
    [Authorize]

    public class EmployeesController : Controller
    {
        static ApplicationDbContext context = new ApplicationDbContext();

        //static ModelContext context = new ModelContext(); 
        // GET: Employees

        
        public ActionResult Index()
        {
            EmployeeViewModel empvm = new EmployeeViewModel();
            empvm.Employees = context.Employees.Include(e => e.Department).ToList();
            empvm.Departments = context.Department.ToList();
            return View(empvm);
        }

        //[HttpGet]
        //public ActionResult Add()
        //{
        //    EmployeeViewModel empvm = new EmployeeViewModel();
        //    empvm.Departments = context.Department.ToList();
        //    ViewBag.Action = "Add";
        //    return View("AddEdit",empvm);
        //}

        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return PartialView("_PartialEmployeeRow",employee);
            }
            EmployeeViewModel empvm = new EmployeeViewModel();
            empvm.Departments = context.Department.ToList();
            return View("AddEdit", empvm);
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(int id)
        {
            Employee emp= context.Employees.FirstOrDefault(e => e.Id == id );
             if (emp != null)
            {
                ViewBag.Action = "Edit";
                EmployeeViewModel empvm = new EmployeeViewModel();
                empvm.Employee = emp;
                empvm.Departments = context.Department.ToList();
                return View("AddEdit", empvm);
            }
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin,Manager")]
        public ActionResult Edit(EmployeeViewModel empvm)
        {
            if (ModelState.IsValid)
            {
                Employee oldemp = context.Employees.FirstOrDefault(e => e.Id == empvm.Employee.Id);
                if (oldemp != null)
                {
                    oldemp.Name = empvm.Employee.Name;
                    oldemp.Age = empvm.Employee.Age;
                    oldemp.Gender = empvm.Employee.Gender;
                    oldemp.Fk_DepartmentId = empvm.Employee.Fk_DepartmentId;
                    oldemp.Email = empvm.Employee.Email;
                    context.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            EmployeeViewModel empviewmodel = new EmployeeViewModel();
            empviewmodel.Employee = empvm.Employee ;
            empviewmodel.Departments = context.Department.ToList();
            return View("AddEdit",empvm);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            Employee emp = context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                ViewBag.Action = "Detail";
                EmployeeViewModel empvm = new EmployeeViewModel();
                empvm.Employee = emp;
                empvm.Departments = context.Department.ToList();
                return View("Detail", empvm);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin,Manager")]
        public async Task<bool> Delete(int id)
        {
            Employee result = context.Employees.FirstOrDefault(e => e.Id == id);
            if (result != null)
            {
                context.Employees.Remove(result);
                await context.SaveChangesAsync();
                return true;
            }
            //return RedirectToAction("Index");
            return false;  
        }
    }
}