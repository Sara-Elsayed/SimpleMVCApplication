using SimpleAuthProject.Models;
using SimpleAuthProject.Models.Entities;
using SimpleAuthProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleAuthProject.Controllers
{
    [Authorize(Roles ="Admin,Manager")]
    public class DepartmentsController : Controller
    {
        static ApplicationDbContext context = new ApplicationDbContext();
        // GET: Departments
        public ActionResult Index()
        {
            return View(context.Department.ToList());
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddEdit");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]

        public ActionResult Add(Department department)
        {
            if (ModelState.IsValid)
            {
                context.Department.Add(department);//name in dbset
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("AddEdit",department);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Department department = context.Department.FirstOrDefault(e => e.Id == id);
            if (department != null)
            {
                ViewBag.Action = "Edit";
                return View("AddEdit", department);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                var oldDept = context.Department.FirstOrDefault(e => e.Id == department.Id);
                if (oldDept != null)
                {
                    oldDept.Name = department.Name;
                    context.SaveChanges();

                }
                return RedirectToAction("Index");
            }
            return View("AddEdit", department);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            var result = context.Department.FirstOrDefault(e => e.Id == id);
            if (result != null)
            {
                context.Department.Remove(result);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}