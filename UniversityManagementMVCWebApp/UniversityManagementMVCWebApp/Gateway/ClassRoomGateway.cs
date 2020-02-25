using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UniversityManagementMVCWebApp.Models;
using UniversityManagementMVCWebApp.Models.Views;

namespace UniversityManagementMVCWebApp.Gateway
{
    public class ClassRoomGateway : ParentGateway
    {
        public List<ClassRoom> GetAllClassRoomInfo()
        {
            Query = "SELECT * FROM SaveClassRoom";
            Command = new SqlCommand(Query, Connection);
            List<ClassRoom> classRooms = new List<ClassRoom>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                classRooms.Add(new ClassRoom()
                {
                    DepartmentID = Convert.ToInt32(Reader["DepartmentID"]),
                    ID = Convert.ToInt32(Reader["ID"]),
                    Name = Reader["Name"].ToString()
                });
            }
            Reader.Close();
            Connection.Close();
            return classRooms;
        }

        public int Save(ClassRoomAllocation classRoomAllocation)
        {
            Query = "INSERT INTO AllocateClassRoom VALUES(@DepartmentID,@CourseID,@RoomID,@Day,@FromTime,@ToTime)";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("DepartmentID", classRoomAllocation.DepartmentID);
            Command.Parameters.AddWithValue("CourseID", classRoomAllocation.CourseID);
            Command.Parameters.AddWithValue("RoomID", classRoomAllocation.RoomID);
            Command.Parameters.AddWithValue("Day", classRoomAllocation.Day);
            Command.Parameters.AddWithValue("FromTime",
                classRoomAllocation.FromTimeHour + " " + classRoomAllocation.FromTimePeriod);
            Command.Parameters.AddWithValue("ToTime",
                classRoomAllocation.ToTimeHour + " " + classRoomAllocation.ToTimePeriod);
            Connection.Open();
            int rowAffected = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffected;
        }

        public List<ClassRoomAllocation> GetClassRoomAllocationInfo(int roomId, string day)
        {
            Query = "SELECT * FROM AllocateClassRoom WHERE RoomID=@roomId AND Day=@day";
            Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("roomId", roomId);
            Command.Parameters.AddWithValue("day", day);
            List<ClassRoomAllocation> classRoomAllocations = new List<ClassRoomAllocation>();
            Connection.Open();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                classRoomAllocations.Add(new ClassRoomAllocation()
                {
                    FromTime = Reader["FromTime"].ToString(),
                    ToTime = Reader["ToTime"].ToString()
                });
            }
            Reader.Close();
            Connection.Close();
            return classRoomAllocations;
        }

        public List<ClassRoomAllocationAndClassSchedule> GetClassSchedule(List<Course> courses)
        {
            List<ClassRoomAllocationAndClassSchedule> classSchedule = new List<ClassRoomAllocationAndClassSchedule>();
            foreach (Course course in courses)
            {
                Query = "SELECT * FROM ClassRoomAllocationAndClassSchedule WHERE Code=@Code";
                Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("Code", course.Code);
                ClassRoomAllocationAndClassSchedule classRoomAllocationAndSchedule =
                    new ClassRoomAllocationAndClassSchedule();
                classRoomAllocationAndSchedule.Code = course.Code;
                classRoomAllocationAndSchedule.Name = course.Name;
                Connection.Open();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    classRoomAllocationAndSchedule.ClassRoomAllocations.Add(new ClassRoomAllocation
                    {
                        RoomName = Reader["RoomName"].ToString(),
                        Day = Reader["Day"].ToString(),
                        FromTime = Reader["FromTime"].ToString(),
                        ToTime = Reader["ToTime"].ToString()
                    });
                }
                Reader.Close();
                Connection.Close();
                classSchedule.Add(classRoomAllocationAndSchedule);
            }
            return classSchedule;
        }
    }
}