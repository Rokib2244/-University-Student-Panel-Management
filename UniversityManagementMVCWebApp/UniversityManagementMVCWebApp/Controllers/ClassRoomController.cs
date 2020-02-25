using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using UniversityManagementMVCWebApp.Manager;
using UniversityManagementMVCWebApp.Models;
using UniversityManagementMVCWebApp.Models.Views;

namespace UniversityManagementMVCWebApp.Controllers
{
    public class ClassRoomController : Controller
    {
        DepartmentManager departmentManager=new DepartmentManager();
        CourseManager courseManager=new CourseManager();
        ClassRoomManager classRoomManager=new ClassRoomManager();
        // GET: /ClassRoom/
        public ActionResult Allocate()
        {
            List<Department> departments = departmentManager.GetAllDepartment();
            departments.Insert(0, new Department()
            {
                ID = 0,
                Code = "--Select a department--"
            });
            List<Course> courses = new List<Course>()
            {
                new Course(){ ID = 0,Code = "--Select a course--",DepartmentId = 0}
            };
            List<ClassRoom> classRooms = new List<ClassRoom>()
            {
                new ClassRoom(){ID = 0,DepartmentID = 0,Name = "--Select a Class room--"}
            };
            List<string> days = GetDays();
            ViewBag.Departments = departments;
            ViewBag.ClassRooms = classRooms;
            ViewBag.Courses = courses;
            ViewBag.Days = days;
            return View();
        }

        [HttpPost]
        public ActionResult Allocate(ClassRoomAllocation classRoomAllocation)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = classRoomManager.Save(classRoomAllocation);
            }
            
            List<Department> departments = departmentManager.GetAllDepartment();
            departments.Insert(0, new Department()
            {
                ID = 0,
                Code = "--Select a department--"
            });
            List<Course> courses = new List<Course>()
            {
                new Course(){ ID = 0,Code = "--Select a course--",DepartmentId = 0}
            };
            List<ClassRoom> classRooms = new List<ClassRoom>()
            {
                new ClassRoom(){ID = 0,DepartmentID = 0,Name = "--Select a Class room--"}
            };
            List<string> days = GetDays();
            
            ViewBag.Departments = departments;
            ViewBag.ClassRooms = classRooms;
            ViewBag.Courses = courses;
            ViewBag.Days = days;
            return View();
        }

        public List<string> GetDays()
        {
            return new List<string>()
            {
                "--Select a Day--","SAT","SUN","MON","TUE","WED","THU","FRI"
            };
        } 
        

        public ActionResult Schedule()
        {
            List<ClassRoomAllocationAndClassSchedule> classSchedule =new List<ClassRoomAllocationAndClassSchedule>();
            List<Department> departments = departmentManager.GetAllDepartment();
            departments.Insert(0, new Department()
            {
                ID = 0,
                Code = "--Select a department--"
            });
            ViewBag.ClassSchedule = classSchedule;
            ViewBag.Departments = departments;
            return View();
        }

        [HttpPost]
        public ActionResult Schedule(Department department)
        {
            List<ClassRoomAllocationAndClassSchedule> classSchedule = classRoomManager.GetClassSchedule(department.ID);
            List<Department> departments = departmentManager.GetAllDepartment();
            departments.Insert(0, new Department()
            {
                ID = 0,
                Code = "--Select a department--"
            });
            ViewBag.ClassSchedule = classSchedule;
            ViewBag.Departments = departments;
            return View();
        }

        public ActionResult GetCourses(int id)
        {
            List<Course> courses = courseManager.GetAllCourses();
            var s = courses.Where(p => p.DepartmentId == id);
            return Json(s);
        }

        public ActionResult GetRooms(int id)
        {
            List<ClassRoom> rooms = classRoomManager.GetAllClassRoomInfo();
            var s = rooms.Where(r => r.DepartmentID == id);
            return Json(s);
        }

        public ActionResult Unallocate()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Unallocate")]
        public ActionResult UnallocatePost()
        {
            return View();
        }
	}
}