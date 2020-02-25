using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Gateway;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Manager
{
    public class CourseManager
    {
        CourseGateway courseGateway=new CourseGateway();
        public List<Course> GetAllCourses()
        {
            return courseGateway.GetAllCourses();
        }

        public string AssignCourse(CourseAssign courseAssign)
        {
            var rowAffected = courseGateway.AssignCourse(courseAssign);
            if (rowAffected[0] > 0 && rowAffected[1] > 0 && rowAffected[2] > 0)
            {
                return "Course Assigned.";
            }
            else
            {
                return "Course Assign failed.";
            }
        }

        public List<Course> GetCoursesByDepartmentId(int id)
        {
            return courseGateway.GetCoursesByDepartmentId(id);
        }
    }
}