using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityManagementMVCWebApp.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public int DesignationID { get; set; }
        public int DepartmentID { get; set; }
        public double TotalCredit { get; set; }
        public double RemainingCredit { get; set; }
    }
}