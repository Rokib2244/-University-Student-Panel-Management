using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Gateway;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Manager
{
    public class TeacherManager
    {
        private TeacherGateway teacherGateway = new TeacherGateway();

        public List<Teacher> GetAllTeachers()
        {
            return teacherGateway.GetAllTeachers();
        }

        
    }
}