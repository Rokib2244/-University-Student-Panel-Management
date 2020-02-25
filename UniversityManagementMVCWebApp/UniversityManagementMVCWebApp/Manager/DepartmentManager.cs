using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Gateway;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Manager
{
    public class DepartmentManager
    {

        DepartmentGateway aDepartmentGateway = new DepartmentGateway();
        public string SaveDepartment(Department department)
        {
            bool hasRows = aDepartmentGateway.CheckDepartment(department);
            if (!hasRows)
            {
                int rowAffected = aDepartmentGateway.SaveDepartment(department);

                if (rowAffected > 0)
                {
                    return "Department Saved Succesfully";
                }
                else
                {
                    return "Sorry! Department Saved Failed";
                }
            }
            else
            {
                return "Department with same Code or Name already exist.";
            }

        }

        public List<Department> GetAllDepartment()
        {
            return aDepartmentGateway.GetAllDepartment();
        }
    }
}