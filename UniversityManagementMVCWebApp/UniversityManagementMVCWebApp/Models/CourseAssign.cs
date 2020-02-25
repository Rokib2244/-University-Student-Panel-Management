using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementMVCWebApp.Models
{
    public class CourseAssign
    {
        [Range(1,Int32.MaxValue,ErrorMessage = "Select a Teacher")]
        public int TeacherID { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Select a Course")]
        public int CourseID { get; set; }
        public double CourseCredit { get; set; }
        public double RemainingCredit { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Select a Department")]
        public int DepartmentID { get; set; }
    }
}