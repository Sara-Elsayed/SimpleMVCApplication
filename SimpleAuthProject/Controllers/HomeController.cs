using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SimpleAuthProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleAuthProject.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext context;
        ApplicationRoleManager roleManager;
        ApplicationUserManager userManager;

        public ApplicationDbContext Context
        {
            get
            {
                return context ?? HttpContext.GetOwinContext().Get<ApplicationDbContext>();
            }
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().Get<ApplicationUserManager>();
            }
        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}