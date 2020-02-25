using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Gateway
{
    public class DepartmentGateway : ParentGateway
    {
     
        public int SaveDepartment(Department department)
        {
            Query = "INSERT INTO SaveDepartment VALUES (@Code,@Name)";

            

            Command = new SqlCommand(Query,Connection);
            Command.Parameters.Clear();
            Command.Parameters.AddWithValue("Code", department.Code);
            Command.Parameters.AddWithValue("Name", department.Name);

            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<Department> GetAllDepartment()
        {
            Query = "Select * from SaveDepartment";
            Command= new SqlCommand(Query,Connection);
            List<Department> departments= new List<Department>();
            Connection.Open();

            Reader = Command.ExecuteReader();

            while (Reader.Read())
            {
                Department department = new Department
                {
                    ID = Convert.ToInt32(Reader["ID"]),
                    Name = Reader["Name"].ToString(),
                    Code = Reader["Code"].ToString()
                };

                departments.Add(department);
            }

            Reader.Close();
            Connection.Close();

            return departments;
        }

        public bool CheckDepartment(Department department)
        {
            Query = "SELECT * FROM SaveDepartment WHERE Code=@Code OR Name=@Name";
            Command=new SqlCommand(Query,Connection);
            Command.Parameters.AddWithValue("Code", department.Code);
            Command.Parameters.AddWithValue("Name", department.Name);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool hasRows = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return hasRows;
        }
    }
}