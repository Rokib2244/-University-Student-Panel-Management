using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Models;

namespace UniversityManagementMVCWebApp.Gateway
{
    public class CourseGateway:ParentGateway
    {
        public List<Course> GetAllCourses()
        {
            Query = "SELECT * FROM SaveCourse";
            Command=new SqlCommand(Query,Connection);
            List<Course> courses=new List<Course>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                courses.Add(new Course()
                {
                    Assigned = Reader["Assigned"].ToString(),
                    ID = Convert.ToInt32(Reader["ID"]),
                    Code = Reader["Code"].ToString(),
                    DepartmentId = Convert.ToInt32(Reader["DepartmentID"]),
                    Name = Reader["Name"].ToString(),
                    Credit = Convert.ToDouble(Reader["Credit"])
                    
                });
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }

        public List<int> AssignCourse(CourseAssign courseAssign)
        {
            Query = "UPDATE SaveCourse SET Assigned='true' WHERE ID=" + courseAssign.CourseID;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffectedInSaveCouseTable = Command.ExecuteNonQuery();
            Connection.Close();
            Query = "UPDATE SaveTeacher SET RemainingCredit=" +
                    (courseAssign.RemainingCredit - courseAssign.CourseCredit) + " WHERE ID=" +
                    courseAssign.TeacherID;
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffectedInSaveTeacherTable = Command.ExecuteNonQuery();
            Connection.Close();
            Query = "INSERT INTO CourseAssign VALUES(" + courseAssign.DepartmentID + "," +
                    courseAssign.TeacherID + "," + courseAssign.CourseID + ")";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffectedInCourseAssignTable = Command.ExecuteNonQuery();
            Connection.Close();

            return new List<int>()
            {
                rowAffectedInCourseAssignTable,rowAffectedInSaveCouseTable,rowAffectedInSaveTeacherTable
            };
        }

        public List<Course> GetCoursesByDepartmentId(int id)
        {
            Query = "SELECT * FROM SaveCourse WHERE DepartmentID=" + id;
            Command = new SqlCommand(Query, Connection);
            List<Course> courses = new List<Course>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                courses.Add(new Course
                {
                    ID=Convert.ToInt32(Reader["ID"]),
                    Code=Reader["Code"].ToString(),
                    Name=Reader["Name"].ToString()
                });
            }
            Reader.Close();
            Connection.Close();
            return courses;
        }
    }
}