using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityManagementMVCWebApp.Manager;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Controllers
{

    public class DepartmentController : Controller
    {
        DepartmentManager aDepartmentManager = new DepartmentManager();
        public ActionResult Save()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Save(Department department)
        {
            if (ModelState.IsValid)
            {
                string message = aDepartmentManager.SaveDepartment(department);
            }
            
            return View();
        }

	}
}