using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Gateway
{
    public class TeacherGateway:ParentGateway
    {
        public List<Teacher> GetAllTeachers()
        {
            Query = "SELECT * FROM SaveTeacher";
            Command=new SqlCommand(Query,Connection);
            List<Teacher> teachers=new List<Teacher>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                teachers.Add(new Teacher()
                {
                    ID = Convert.ToInt32(Reader["ID"]),
                    Name = Reader["Name"].ToString(),
                    DepartmentID = Convert.ToInt32(Reader["DepartmentID"]),
                    TotalCredit = Convert.ToDouble(Reader["TotalCredit"]),
                    RemainingCredit = Convert.ToDouble(Reader["RemainingCredit"])
                });
            }
            Reader.Close();
            Connection.Close();
            return teachers;
        }
    }
}