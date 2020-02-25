using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityManagementMVCWebApp.Models
{
    public class Department
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Department Code is required")]
        [StringLength(7,MinimumLength = 2,ErrorMessage = "Code name must be 2 to 7 character long")]
        public string Code { get; set; }
        [Required(ErrorMessage = "Department Name is required")]
        public string Name { get; set; }


    }
}